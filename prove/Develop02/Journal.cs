class Journal
{
    private List<Entry> entries = new List<Entry>();
    private List<Entry> loadedEntries = new List<Entry>();
    private List<string> prompts = new List<string> { "Who was the most interesting person I interacted with today? ", "What was the best part of my day? ", "How did I see the hand of the Lord in my life today? ", "What was the strongest emotion I felt today? ", "If I had one thing I could do over today what would it be? ", "Who was kindest to me today? ", "How did I come closer to fulfilling my life goals today? ", "What is the most impressive thing I did today? " };
    private File jFile = new File("journal.txt");
    private int index;
    private string prompt;
    // private string date;
    private string response;
    private Entry entry;
    private Random rand;
    DateTime theCurrentTime;
    string dateText;
    public void WriteNewEntry()
    {
        rand = new Random();
        index = rand.Next(prompts.Count);
        prompt = prompts[index];
        // Console.WriteLine("What is the date? ");
        // date = Console.ReadLine();
        theCurrentTime = DateTime.Now;
        dateText = theCurrentTime.ToShortDateString();
        Console.WriteLine(prompt);
        response = Console.ReadLine();
        // entry = new Entry(date, prompt, response);
        entry = new Entry(dateText, prompt, response);
        entries.Add(entry);
    }
    public void LoadJournal()
    {
        loadedEntries = jFile.Read();
        foreach (Entry entry in loadedEntries)
        {
            entries.Add(entry);
        }
    }
    public void SaveJournal()
    {
        jFile.Write(entries);
    }
    public void DislayJournal()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }
}