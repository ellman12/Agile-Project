using AgileProject.Backend;
using System.Diagnostics;
using System.Linq;

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

        foreach (var folder in folders)
        {
            Assert.IsTrue(Connection.DeleteFolder(folder.FolderID));
        }
    }

    [Test]
    public void SetCreationTest()
    {
        //Connection.CreateUser("Guy 1", "Nassword", "Guy", "One", "TheGuy@mail.org");
        Guid user = Connection.ValidateUser("Guy 1", "Nassword");

        Assert.IsTrue(Connection.CreateFolder(user, "Folder 1"));

        var folders = Connection.GetFoldersFromUser(user);

        Assert.IsTrue(Connection.CreateSet(user, "Set 1", folders[0].FolderID));

        var sets = Connection.GetSetsFromFolder(folders[0].FolderID);

        foreach (var set in sets)
        {
            Assert.IsTrue(Connection.DeleteSet(set.SetID));
        }

        foreach (var folder in folders)
        {
            Assert.IsTrue(Connection.DeleteFolder(folder.FolderID));
        }
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

        
    }
}