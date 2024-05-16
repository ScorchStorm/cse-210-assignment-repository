class File
{
    private string _path;
    private string _date;
    private string _prompt;
    private string _response;
    private List<Entry> _savedEntries = new List<Entry>();
    private List<string> _savedEntryData = new List<string>();
    private string[] _lines;
    private string _entryData;
    private Entry _entry;
    public File(string path)
    {
        _path = path;
    }

    public List<Entry> Read()
    {
        _savedEntries = new List<Entry>();
        foreach (Entry _entry in _savedEntries)
            _savedEntryData.Add(_entry.GetEntryData());
        _lines = System.IO.File.ReadAllLines(_path);
        foreach (string _line in _lines)
        {
            string[] parts = _line.Split(",");
            _date = parts[0];
            _prompt = parts[1];
            _response = parts[2];
            _entry = new Entry(_date, _prompt, _response);
            if (!_savedEntryData.Contains(_entry.GetEntryData())) // check whether each item is already saved in the file
            {
                _savedEntries.Add(_entry);
            }
        }
        return _savedEntries;
    }

    public void Write(List<Entry> _entries)
    {
        _savedEntries = Read();
        foreach (Entry _entry in _savedEntries)
            _savedEntryData.Add(_entry.GetEntryData());
        using (StreamWriter outputFile = new StreamWriter(_path, true)) // Create or append to the CSV file
        {
            foreach (Entry _entry in _entries)
            {
                if (!_savedEntryData.Contains(_entry.GetEntryData())) // check whether each item is already saved in the file
                {
                    _entryData = _entry.GetEntryData();
                    outputFile.WriteLine(_entryData); // You can add text to the file with the WriteLine method
                }
            }
        }
    }
}