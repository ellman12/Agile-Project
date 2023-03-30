using Npgsql;

namespace AgileProject.Backend;

public static class Connection
{
	private const string CONNECTION_STRING = "Host=localhost; Port=5432; User Id=postgres; Password=cis424; Database=AgileProject";
	public static readonly NpgsqlConnection connection = new(CONNECTION_STRING);

	public static void Open()
	{
		if (connection.State == System.Data.ConnectionState.Closed)
		{
			connection.Open();
		}
	}

	public static void Close()
	{
		if (connection.State == System.Data.ConnectionState.Open)
		{
			connection.Close();
		}
	}

	public static void CreateUser(string username, string password, string first_name, string last_name, string email)
	{
		try
		{
			Open();
			using NpgsqlCommand cmd = new("Insert INTO users(username, first_name, last_name, email, password) " +
			                              "Values(@username, @first_name, @last_name, @email, crypt(@password, gen_salt('bf')))", connection);
			cmd.Parameters.AddWithValue("@username", username);
			cmd.Parameters.AddWithValue("@password", password);
			cmd.Parameters.AddWithValue("@first_name", first_name);
			cmd.Parameters.AddWithValue("@last_name", last_name);
			cmd.Parameters.AddWithValue("@email", email);
			
			cmd.ExecuteNonQuery();
		}
		catch (NpgsqlException e)
		{
			Console.WriteLine($"Error in createUser: {e.Message}");
		}
		finally
		{
			Close();
		}
	}

	public static Guid ValidateUser(string username, string pass)
	{
		try
		{
			Open();
			using NpgsqlCommand cmd = new("SELECT * FROM users WHERE username = @username and password = crypt(@password, password)", connection);
			cmd.Parameters.AddWithValue("@username", username);
			cmd.Parameters.AddWithValue("@password", pass);
			cmd.ExecuteNonQuery();
			using NpgsqlDataReader r = cmd.ExecuteReader();
			if (r.HasRows)
			{
				r.Read();
				return r.GetGuid(0);
			}
			else
			{
				return Guid.Empty;
			}
		}
		catch (NpgsqlException e)
		{
			Console.WriteLine($"Error in ValidateUser: {e.Message}");
			return Guid.Empty;
		}
		finally
		{
			Close();
		}
	}
    public static void CreateCard(Guid set_id, string question, string answer)
    {
        try
        {
            Open();
            using NpgsqlCommand cmd = new("INSERT INTO flashcards (set_id, question, answer) VALUES (@set_id, @question, @answer)", connection);
            cmd.Parameters.AddWithValue("@set_id", set_id);
            cmd.Parameters.AddWithValue("@question", question);
            cmd.Parameters.AddWithValue("@answer", answer);
            cmd.ExecuteNonQuery();
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error in CreateCard: {e.Message}");
        }
        finally
        {
            Close();
        }

    }

    public static void EditCard(Guid set_id, Guid card_id, string question, string answer)
    {
        try
        {
            Open();
            using NpgsqlCommand cmd = new("UPDATE flashcards SET set_id = @set_id, question = @question, answer = @answer WHERE card_id = @card_id", connection);
            cmd.Parameters.AddWithValue("@set_id", set_id);
            cmd.Parameters.AddWithValue("@card_id", card_id);
            cmd.Parameters.AddWithValue("@question", question);
            cmd.Parameters.AddWithValue("@answer", answer);
            cmd.ExecuteNonQuery();
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error in EditCard: {e.Message}");
        }
        finally
        {
            Close();
        }
    }

    //No Folder
    public static bool CreateSet(Guid user, string name)
	{
        try
        {
            Open();
            using NpgsqlCommand cmd = new("INSERT INTO sets (creator, name) VALUES (@user_id, @name)", connection);
            cmd.Parameters.AddWithValue("@user_id", user);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();

            return true;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error in CreateSet-NoFolder: {e.Message}");
            return false;
        }
        finally
        {
            Close();
        }
    }
    //With Folder
    public static bool CreateSet(Guid user, string name, Guid folder)
    {
        try
        {
            Open();
            using NpgsqlCommand cmd = new("INSERT INTO sets (creator, name, folder_id) VALUES (@user_id, @name, @folder_id)", connection);
            cmd.Parameters.AddWithValue("@user_id", user);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@folder_id", folder);
            cmd.ExecuteNonQuery();

            return true;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error in CreateSet-Folder: {e.Message}");
            return false;
        }
        finally
        {
            Close();
        }
    }

    public static bool CreateFolder(Guid user, string name)
    {
        try
        {
            Open();
            using NpgsqlCommand cmd = new("INSERT INTO folders (creator, name) VALUES (@user_id, @name)", connection);
            cmd.Parameters.AddWithValue("@user_id", user);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();

            return true;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error in CreateFolder: {e.Message}");
            return false;
        }
        finally
        {
            Close();
        }
    }

    #region GetMethods
    public static List<Card> GetCardsFromSet(Guid setID)
	{
        try
        {
            Open();
            using NpgsqlCommand cmd = new("SELECT question, answer, card_id FROM flashcards WHERE set_id = @set_id", connection);
            cmd.Parameters.AddWithValue("@set_id", setID);
            cmd.ExecuteNonQuery();
            using NpgsqlDataReader r = cmd.ExecuteReader();

			List<Card> cards = new List<Card>();

            while (r.Read()) cards.Add(new Card(r.GetString(0), r.GetString(1), r.GetGuid(2)));

            return cards;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error in GetCardsFromSet: {e.Message}");
            return new List<Card>();
        }
        finally
        {
            Close();
        }
    }

    public static List<Set> GetSetsFromFolder(Guid folderID)
    {
        try
        {
            Open();
            using NpgsqlCommand cmd = new("SELECT name, set_id FROM sets WHERE folder_id = @folder_id", connection);
            cmd.Parameters.AddWithValue("@folder_id", folderID);
            cmd.ExecuteNonQuery();
            using NpgsqlDataReader r = cmd.ExecuteReader();

            List<Set> sets = new List<Set>();

            while (r.Read()) sets.Add(new Set(r.GetString(0), r.GetGuid(1)));

            return sets;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error in GetSetsFromFolder: {e.Message}");
            return new List<Set>();
        }
        finally
        {
            Close();
        }
    }

    public static List<Folder> GetFoldersFromUser(Guid userID)
    {
        try
        {
            Open();
            using NpgsqlCommand cmd = new("SELECT name, folder_id FROM folders WHERE creator = @user_id", connection);
            cmd.Parameters.AddWithValue("@user_id", userID);
            cmd.ExecuteNonQuery();
            using NpgsqlDataReader r = cmd.ExecuteReader();

            List<Folder> sets = new List<Folder>();

            while (r.Read()) sets.Add(new Folder(r.GetString(0), r.GetGuid(1)));

            return sets;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error in GetFolderFromUser: {e.Message}");
            return new List<Folder>();
        }
        finally
        {
            Close();
        }
    }
    #endregion

    public static bool DeleteFolder(Guid folder)
    {
        try
        {
            Open();
            using NpgsqlCommand cmd = new("DELETE FROM folders where folder_id = @folder_id", connection);
            cmd.Parameters.AddWithValue("@folder_id", folder);
            cmd.ExecuteNonQuery();
            Open();
            return true;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error in DeleteFolder: {e.Message}");
            return false;
        }
        finally
        {
            Close();
        }

    }

    public static bool DeleteSet(Guid set)
    {
        try
        {
            Open();
            using NpgsqlCommand cmd = new("DELETE FROM flashcards where set_id = @set_id", connection);
            cmd.Parameters.AddWithValue("@set_id", set);
            cmd.ExecuteNonQuery();
            Open();
            using NpgsqlCommand cmd2 = new("DELETE FROM sets where set_id = @set_id", connection);
            cmd2.Parameters.AddWithValue("@set_id", set);
            cmd2.ExecuteNonQuery();
            return true;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error in DeleteSet: {e.Message}");
            return false;
        }
        finally
        {
            Close();
        }

    }

    public static bool DeleteCard(Guid card_id)
    {
        try
        {
            Open();
            using NpgsqlCommand cmd = new("DELETE FROM flashcards where card_id = @card_id", connection);
            cmd.Parameters.AddWithValue("@card_id", card_id);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error in DeleteCard: {e.Message}");
            return false;
        }
        finally
        {
            Close();
        }

    }
}