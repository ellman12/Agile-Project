namespace AgileProjectTest;
using AgileProjectTest.BackendTest;

public class Tests
{

    [SetUp]
	public void Setup()
	{
	}

	[Test]
	public void Test1()
	{
		Assert.Pass();
	}

	[Test]
	public void CardCreationTest1() 
	{
		Card card1 = new("Front Side", "Back Side");

		Assert.IsNotNull(card1);
		Assert.IsNotNull(card1.Front);
		Assert.IsTrue(card1.Front == "Front Side");
        Assert.IsTrue(card1.Back == "Back Side");
    }

	[Test]
	public void SetCreationTest1()
	{
        Card card1 = new("Front Side 1", "Back Side 1");
        Card card2 = new("Front Side 2", "Back Side 2");

        Set set1 = new();

		Assert.IsNotNull(set1);

		set1.AddCard(card1);
        set1.AddCard(card2);

		Assert.IsTrue(set1.Size() == 2);

		Assert.IsNotNull(set1.GetCard(1));
        Assert.IsTrue(set1.GetCard(1).Front == "Front Side 2");
    }

	//Edit to change what types of sets are made
	Set makeTrialSetDefined(int start, int end)
	{
        Set set1 = new();
        for (int i = start; i <= end; i++)
		{
             set1.AddCard(new($"Front Side {i}", $"Back Side {i}"));
        }

		return set1;
    }
    Set makeTrialSet()
    {
        Card card1 = new("Front Side 1", "Back Side 1");
        Card card2 = new("Front Side 2", "Back Side 2");

        Set set1 = new();

        set1.AddCard(card1);
        set1.AddCard(card2);

        return set1;
    }

    [Test]
	public void FolderCreationTest1() 
	{
        Set set1 = makeTrialSetDefined(0, 2);
		Set set2 = makeTrialSetDefined(2, 4);

		Assert.IsNotNull(set1);
		Assert.IsNotNull(set2);

		Folder folder1 = new("Folder 1");

		Assert.IsNotNull(folder1);
		Assert.IsTrue(folder1.FolderName == "Folder 1");

		folder1.AddSet(set1);
		folder1.AddSet(set2);

		Assert.IsTrue(folder1.Size() == 2);
    }

	[Test]
	public void FolderSetDeletion()
	{
        Set set1 = makeTrialSetDefined(0, 2);
        Set set2 = makeTrialSetDefined(2, 4);
        Folder folder1 = new("Folder 1");
        folder1.AddSet(set1);
        folder1.AddSet(set2);

        Assert.IsTrue(folder1.Size() == 2);

		folder1.RemoveSetByPlace(0);

        Assert.IsTrue(folder1.Size() == 1);
    }
}