// ===============================
//            Choice            // Gives the user a set of choices, and lets them make a choice by entering the index of the choice
// -------------------------------
//     - int index
//     - string prompt
//     - List<string> choices
// -------------------------------
//     + Choice(List<string> choices)
//     + MakeChoice()
// ===============================

using Newtonsoft.Json;
class Choice
{
    [JsonProperty]
    private string input;
    [JsonProperty]
    private string prompt;
    [JsonProperty]
    private List<string> choices;

    public Choice(string Prompt, List<string> Choices)
    {
        prompt = Prompt;
        choices = Choices;
    }

    public int MakeChoice()
    {
        Console.WriteLine(prompt);
        while (true)
        {
            // [JsonProperty]
            int index = 1;
            foreach (string choice in choices)
            {
                Console.WriteLine($"{index}. {choice}");
                index++;
            }
            // [JsonProperty]
            input = Console.ReadLine();
            try
            {
                // [JsonProperty]
                index = int.Parse(input);
                Console.WriteLine();
                return index;
            }
            catch
            {
                Console.WriteLine($"Invalid input. Please enter a number between 1 and {choices.Count}");
            }
        }
    }
}
