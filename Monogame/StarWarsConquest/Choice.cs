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
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace StarWarsConquest;
class Choice
{
    private string input;
    private string prompt;
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
            int index = 1;
            foreach (string choice in choices)
            {
                Console.WriteLine($"{index}. {choice}");
                index++;
            }
            input = Console.ReadLine();
            try
            {
                index = int.Parse(input);
                if (index >= 1 && index <= choices.Count)
                    return index-1;
                else
                    Console.WriteLine($"Invalid input. Please enter a number between 1 and {choices.Count}");
            }
            catch
            {
                Console.WriteLine($"Invalid input. Please enter a number between 1 and {choices.Count}");
            }
        }
    }
}
