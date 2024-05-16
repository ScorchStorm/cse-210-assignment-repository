class File
{
    private string path;
    private string date;
    private string prompt;
    private string response;
    private List<Entry> savedEntries = new List<Entry>();
    private List<string> savedEntryData = new List<string>();
    private string[] lines;
    private string entryData;
    private Entry entry;
    public File(string path)
    {
        this.path = path;
    }

    public List<Entry> Read()
    {
        savedEntries = new List<Entry>();
        foreach (Entry entry in savedEntries)
            savedEntryData.Add(entry.GetEntryData());
        lines = System.IO.File.ReadAllLines(path);
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            date = parts[0];
            prompt = parts[1];
            response = parts[2];
            entry = new Entry(date, prompt, response);
            if (!savedEntryData.Contains(entry.GetEntryData())) // check whether each item is already saved in the file
            {
                savedEntries.Add(entry);
            }
        }
        return savedEntries;
    }

    public void Write(List<Entry> entries)
    {
        savedEntries = Read();
        foreach (Entry entry in savedEntries)
            savedEntryData.Add(entry.GetEntryData());
        using (StreamWriter outputFile = new StreamWriter(path, true)) // Create or append to the CSV file
        {
            foreach (Entry entry in entries)
            {
                if (!savedEntryData.Contains(entry.GetEntryData())) // check whether each item is already saved in the file
                {
                    entryData = entry.GetEntryData();
                    outputFile.WriteLine(entryData); // You can add text to the file with the WriteLine method
                }
            }
        }
    }
}