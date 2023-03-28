using Npgsql;

namespace AgileProject.Backend;

public class Connection
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
			                              "Values(@username, @first_name, @last_name, @email, crypt(@password, gen_salt('bf)))");
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
			using NpgsqlCommand cmd = new("SELECT * FROM users WHERE username = @username and password= crypt(@pass, gen_salt('bf'))");
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
}