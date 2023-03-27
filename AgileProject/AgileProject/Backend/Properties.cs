namespace AgileProject.Backend;
public record Card
{
    public string Question { get; set; }
    public string Answer { get; set; }
    public Guid CardId { get; set; }
    public DateTime Created { get; private set; }

    #region constructors
    public Card(string question, string answer)
    {
        Question = question;
        Answer = answer;
        CardId = Guid.NewGuid();
        Created = DateTime.Now;
    }

    public Card(string question, string answer, Guid id)
    {
        Question = question;
        Answer = answer;
        CardId = id;
        Created = DateTime.Now;
    }

    public Card(string question, string answer, Guid id, DateTime date)
    {
        Question = question;
        Answer = answer;
        CardId = id;
        Created = date;
    }
    #endregion
}

public record Set
{
    public string Name { get; set; }
    public Guid SetID { get; set; }
    public DateTime Created { get; private set; }

    #region constructors
    public Set(string name)
    {
        Name = name;
        SetID = Guid.NewGuid();
        Created = DateTime.Now;
    }

    public Set(string name, Guid id)
    {
        Name = name;
        SetID = id;
        Created = DateTime.Now;
    }
    public Set(string name, DateTime date)
    {
        Name = name;
        SetID = Guid.NewGuid();
        Created = date;
    }

    public Set(string name, Guid id, DateTime date)
    {
        Name = name;
        SetID = id;
        Created = date;
    }
    #endregion
}

public record Folder
{
    public string Name { get; set; }
    public Guid FolderID { get; set; }
    public bool Public { get; set; }
    public DateTime Created { get; private set; }

    #region constructors
    public Folder(string name)
    {
        Name = name;
        FolderID = Guid.NewGuid();
        Public = false;
        Created = DateTime.Now;
    }
    public Folder(string name, bool isPublic)
    {
        Name = name;
        FolderID = Guid.NewGuid();
        Public = isPublic;
        Created = DateTime.Now;
    }

    public Folder(string name, Guid id)
    {
        Name = name;
        FolderID = id;
        Public = false;
        Created = DateTime.Now;
    }

    public Folder(string name, Guid id, bool isPublic)
    {
        Name = name;
        FolderID = id;
        Public = isPublic;
        Created = DateTime.Now;
    }

    public Folder(string name, Guid id, bool isPublic, DateTime date)
    {
        Name = name;
        FolderID = id;
        Public = isPublic;
        Created = date;
    }
    #endregion
}
