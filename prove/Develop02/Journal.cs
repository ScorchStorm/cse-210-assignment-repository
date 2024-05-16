class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<Entry> _loadedEntries = new List<Entry>();
    private List<string> _prompts = new List<string> { "Who was the most interesting person I interacted with today? ", "What was the best part of my day? ", "How did I see the hand of the Lord in my life today? ", "What was the strongest emotion I felt today? ", "If I had one thing I could do over today what would it be? ", "Who was kindest to me today? ", "How did I come closer to fulfilling my life goals today? ", "What is the most impressive thing I did today? " };
    private File _jFile = new File("journal.txt");
    private int _index;
    private string _prompt;
    // private string date;
    private string _response;
    private Entry _entry;
    private Random _rand;
    DateTime _theCurrentTime;
    string _dateText;
    public void WriteNewEntry()
    {
        _rand = new Random();
        _index = _rand.Next(_prompts.Count);
        _prompt = _prompts[_index];
        // Console.WriteLine("What is the date? ");
        // date = Console.ReadLine();
        _theCurrentTime = DateTime.Now;
        _dateText = _theCurrentTime.ToShortDateString();
        Console.WriteLine(_prompt);
        _response = Console.ReadLine();
        // entry = new Entry(date, prompt, response);
        _entry = new Entry(_dateText, _prompt, _response);
        _entries.Add(_entry);
    }
    public void LoadJournal()
    {
        _loadedEntries = _jFile.Read();
        foreach (Entry _entry in _loadedEntries)
        {
            _entries.Add(_entry);
        }
    }
    public void SaveJournal()
    {
        _jFile.Write(_entries);
    }
    public void DislayJournal()
    {
        foreach (Entry _entry in _entries)
        {
            _entry.Display();
        }
    }
}