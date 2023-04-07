using AgileProject.Backend;
using AgileProject.Pages;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;

namespace AgileProjectTest;

[TestFixture]
public class AgileTest
{
	[Test]
	public void HelloWorld()
	{
		Console.WriteLine("hi");
	}

	[Test]
	public void FolderCreationTest()
	{
		//Connection.CreateUser("Guy 1", "Nassword", "Guy", "One", "TheGuy@mail.org");
		Guid user = Connection.ValidateUser("Guy 1", "Nassword");

        Assert.IsTrue(Connection.CreateFolder(user, "Folder 2"));

        var folders = from folder in Connection.GetFoldersFromUser(user) where folder.Name == "Folder 2" select folder;
        /*
        foreach (var folder in folders)
        {
            Assert.IsTrue(Connection.DeleteFolder(folder.FolderID));
        }
        */
    }

    [Test]
    public void SetCreationTest()
    {
        //Connection.CreateUser("Guy 1", "Nassword", "Guy", "One", "TheGuy@mail.org");
        Guid user = Connection.ValidateUser("Guy 1", "Nassword");

        Assert.IsTrue(Connection.CreateFolder(user, "Folder set creation"));

        var folder = (from f in Connection.GetFoldersFromUser(user) where f.Name == "Folder set creation" select f).First();

        Assert.IsTrue(Connection.CreateSet(user, "Set creation 1", folder.FolderID));

        var set = (from s in Connection.GetSetsFromFolder(folder.FolderID) where s.Name == "Set creation 1" select s).First();

        Assert.IsTrue(Connection.DeleteSet(set.SetID));

        Assert.IsTrue(Connection.DeleteFolder(folder.FolderID));
    }

    [Test]
    public void CardCreationTest()
    {
        //Connection.CreateUser("Guy 1", "Nassword", "Guy", "One", "TheGuy@mail.org");
        Guid user = Connection.ValidateUser("Guy 1", "Nassword");

        Assert.IsTrue(Connection.CreateFolder(user, "Folder 1"));

        var folders = Connection.GetFoldersFromUser(user);

        Assert.IsTrue(Connection.CreateSet(user, "Set 1", folders[0].FolderID));

        var sets = Connection.GetSetsFromFolder(folders[0].FolderID);

        Guid selectedSet = Guid.Empty;
        foreach (var set in sets)
        {
            if(set.Name == "Set 1")
            {
                selectedSet = set.SetID;
                break;
            }
        }

        Assert.IsTrue(selectedSet != Guid.Empty);
        Connection.CreateCard(selectedSet, "Who", "Where");

        var card = from c in Connection.GetCardsFromSet(selectedSet) select c;

        foreach (var c in card)
            Assert.IsTrue(Connection.DeleteCard(c.CardId));

        Assert.IsTrue(Connection.DeleteSet(selectedSet));
    }

    [Test]
    public void FolderEditTest()
    {
        Guid user = Connection.ValidateUser("Guy 1", "Nassword");
        string changedName = "Folder Changed Name";

        Assert.IsTrue(Connection.CreateFolder(user, "Folder Edit Test"));

        var folders = from folder in Connection.GetFoldersFromUser(user) where folder.Name == "Folder Edit Test" select folder;

        Assert.IsTrue(Connection.EditFolder(folders.First().FolderID, changedName));
        Assert.IsTrue((from Folder folder in Connection.GetFoldersFromUser(user) where folder.Name == changedName select folder).Count() == 1);

        
        folders = from f in Connection.GetFoldersFromUser(user) where f.Name == changedName select f;

        foreach (var folder in folders)
        {
            Assert.IsTrue(Connection.DeleteFolder(folder.FolderID));
        }
        
    }

    [Test]
    public void SetEditTest()
    {
        Guid user = Connection.ValidateUser("Guy 1", "Nassword");
        string originalName = "Set Origin Name";
        string changedName = "Set Changed Name";

        Assert.IsTrue(Connection.CreateSet(user, originalName));

        var set = (from s in Connection.GetSetsFromUser(user) where s.Name == originalName select s).First();

        Assert.IsTrue(Connection.EditSet(set.SetID, changedName));

        set = (from s in Connection.GetSetsFromUser(user) where s.Name == changedName select s).First();

        Assert.IsTrue(set.Name == changedName);

        Assert.IsTrue(Connection.DeleteSet(set.SetID));
    }
}