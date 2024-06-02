class LoadFile
{
    string filename;
    List<Scripture> scriptures = new List<Scripture>();
    public LoadFile(string Filename)
    {
        filename = Filename;
    }
    public List<Scripture> Read()
    {
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            List<string> partsNew = new List<string>(parts[0].Split(' '));
            string book = string.Join(" ", partsNew.GetRange(0, partsNew.Count - 1));
            int chapter = int.Parse(partsNew.Last().Split(':')[1]);
            int verse = int.Parse(parts[0].Split(':')[1]);
            string text = parts[1];
            scriptures.Add(new Scripture(book, chapter, verse, text));
        }
        return scriptures;
    }
}