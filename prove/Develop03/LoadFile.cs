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
            // Console.WriteLine($"line = {line}");
            string[] parts = line.Split("|");
            // Console.WriteLine($"line = {line}");
            // Console.WriteLine($"parts = {parts}");
            // string reff = parts[0];
            // string book = parts[0].Split(' ');
            // string book = (parts[0].Split(' ')).GetRange(0, (parts[0].Split(' ')).Count - 1);
            // Console.WriteLine($"parts[0] = {parts[0]}");
            // Console.WriteLine($"parts[0] = {parts[0]}");
            // Console.WriteLine($"parts[0].Split('e') = {parts[0].Split('e')}");
            // Console.WriteLine($"parts[0].Split(' ') = {parts[0].Split(' ')}");
            List<string> partsNew = new List<string>(parts[0].Split(' '));
            // Console.WriteLine($"partsNew = {partsNew}");
            string book = string.Join(" ", partsNew.GetRange(0, partsNew.Count - 1));
            // Console.WriteLine($"parts[0] = {parts[0]}");
            // Console.WriteLine($"parts[0].Split(' ').Last() = {parts[0].Split(' ').Last()}");
            // Console.WriteLine($"parts[0].Split(' ').Last().Split(':')[0] = {parts[0].Split(' ').Last().Split(':')[0]}");
            int chapter = int.Parse(partsNew.Last().Split(':')[1]);
            int verse = int.Parse(parts[0].Split(':')[1]);
            string text = parts[1];
            scriptures.Add(new Scripture(book, chapter, verse, text));
        }
        return scriptures;
    }
}