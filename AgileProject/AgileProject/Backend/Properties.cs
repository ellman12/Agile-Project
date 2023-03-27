namespace AgileProject.Backend;
public record Card
{
    public string Question { get; set; }
    public string Answer { get; set; }
    public Guid CardId { get; set; }
    public DateTime Created { get; private set; }

    public Card(string question, string answer)
    {
        Question = question;
        Answer = answer;
        CardId = Guid.NewGuid();
        Created = DateTime.Now;
    }
}

public record Set
{
    public string Name { get; set; }
    public Guid SetID { get; set; }
    public DateTime Created { get; private set; }

    public Set(string name)
    {
        Name = name;
        SetID = Guid.NewGuid();
        Created = DateTime.Now;
    }
}

public record Folder
{
    public string Name { get; set; }
    public Guid FolderID { get; set; }
    public bool Public { get; set; }
    public DateTime Created { get; private set; }

    public Folder(string name)
    {
        Name = name;
        FolderID = Guid.NewGuid();
        Public = false;
        Created = DateTime.Now;
    }
}
