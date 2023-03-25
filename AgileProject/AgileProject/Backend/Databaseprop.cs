namespace AgileProject.Backend
{
    public record Card
    {
        public string Front { get; set; }
        public string Back { get; set; }

        /*
        //ID if needed
        public string ID { get; set; }
        //Name if needed
        public string Name { get; set; }
        */
    }

    public record Set
    {
        public string SetName { get; set; }
        public List<Card> Cards { get; set;}
    }

    public record Folder
    {
        public string FolderName { get; set; }
        public List<Set> Sets { get; set;}
    }
}
