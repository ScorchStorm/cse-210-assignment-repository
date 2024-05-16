class Entry
{
    private string date;
    private string prompt;
    private string response;
    public Entry(string Date, string Prompt, string Response)
    {
        date = Date;
        prompt = Prompt;
        response = Response;
    }
    public void Display()
    {
        Console.WriteLine($"Date: {date}");
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine($"Response: {response}");
    }
    
    public string GetEntryData()
    {
        return $"{date}, {prompt}, {response}";
    }
}