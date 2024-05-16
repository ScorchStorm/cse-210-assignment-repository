class Entry
{
    private string _date;
    private string _prompt;
    private string _response;
    public Entry(string Date, string Prompt, string Response)
    {
        _date = Date;
        _prompt = Prompt;
        _response = Response;
    }
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
    }
    
    public string GetEntryData()
    {
        return $"{_date}, {_prompt}, {_response}";
    }
}