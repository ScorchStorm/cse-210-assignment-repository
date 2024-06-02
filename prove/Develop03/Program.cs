// ===============================
//           Program
// -------------------------------
//     - List<Reference> references
// -------------------------------
//     + SelectScripture()      // Prompts the User to select the index of a scripture
//     + SelectHiddenType()     // Prompts the User to select whether they want hidden words to show the first letter or not
//     + Prompt()               // Prompt the user to press the enter key or type quit.
//     + Clear()                // Clear the console screen and display the complete scripture, including the reference and the text.
//     + Quit()                 // Ends the program
//     + HideMoreVerses()       // This hides a few random words in the scripture, clears the console screen, and displays the scripture again.
// ===============================

// ===============================
//            Choice            // Gives the user a set of choices, and lets them make a choice by entering the index of the choice
// -------------------------------
//     - int index
//     - string input
//     - List<string> choices
// -------------------------------
//     + Choice(List<string> choices)
//     + MakeChoice()
// ===============================

// ===============================
//             File
// -------------------------------
//     + string fileAddress
// -------------------------------
//     + File(string fileAddress)
//     + Read()
// ===============================

// ===============================
//           Reference
// -------------------------------
//     - List<Scriptures> scriptures
//     - string book
//     - string chapter
//     - List<string> verses
// -------------------------------
//     + Reference(string book, string chapter, List<string> verses)
//     + SplitScripture(text)
//     + ShowReference(text)
// ===============================

// ===============================
//           Scripture
// -------------------------------
//     - string ref
//     - List<Word> words
// -------------------------------
//     + Scripture(string text, string reference)
//     + SplitScripture(text)
//     + HideFirstLetters(text)
// ===============================


using System;

class Program
{
    static string filename = "scripture.txt";

    static void Main(string[] args)
    {
        List<Scripture> scriptures = LoadScriptures(filename);  // Loads the scriptures into memory from the TXT file
        Console.WriteLine("Welcome to the Scripture Memorization Program!");
        Console.WriteLine();
        Random rand = new Random();
        int ind = rand.Next(scriptures.Count);
        Scripture scripture = scriptures[ind];

        string prompt = "Please choose from one of the following options to begin your quest to memorize lifechanging scriptures!";
        while (true)
        {
            List<string> choices = new List<string>{"Select a scripture to memorize", "Be given a random scripture to memorize", "Change hidden word settings", "Exit the program"};
            Choice choice = new Choice(prompt, choices);
            int index = choice.MakeChoice();
            if (index == 0)
            {
                scripture = SelectScripture(scriptures);      // Prompts the User to select the index of a scripture
                Prompt(scripture);
            }
            else if (index == 1)
            {
                rand = new Random();
                ind = rand.Next(scriptures.Count);
                scripture = scriptures[ind];
                Prompt(scripture);
            }
            else if (index == 2)
            {
                SelectHiddenType(scripture);                           // Prompts the User to select whether they want hidden words to show the first letter or not
            }
        }
    }

    public static List<Scripture> LoadScriptures(string filename)
    {
        LoadFile file = new LoadFile(filename);
        List<Scripture> scriptures = file.Read();
        return scriptures;
    }

    public static Scripture SelectScripture(List<Scripture> scriptures)
    {
        List<string> choices = new List<string>();
        string prompt = "Enter the index of the scripture you would like to memorize.";
        foreach (Scripture scripture in scriptures)
        {
            choices.Add(scripture.ReturnStringReference());
        }
        Choice choice = new Choice(prompt, choices);
        int index = choice.MakeChoice();
        return scriptures[index];
    }

    public static void SelectHiddenType(Scripture scripture)
    {
        List<bool> options = new List<bool>{false, true};
        string prompt = "Enter the index of the hidden scripture type you would like to use.";
        List<string> choices = new List<string>{"Hide all characters of each word", "Hide all characters besides the first letter of each word."};
        Choice choice = new Choice(prompt, choices);
        int index = choice.MakeChoice();
        if (options[index])
        {
            scripture.HideFirstLetters();
        }
    }

    static void Prompt(Scripture scripture)
    {
        while (true)
        {
            scripture.ShowWords();
            int hideNumber = 8; // The number of additional words to hide each time the enter key is pressed
            {
                Console.WriteLine("Press Enter to hide more verses or type quit to end the program");
                string input = Console.ReadLine();
                if (input == "quit")
                {
                    Environment.Exit(1);                  // Ends the program
                }
                else if (input == "")
                {
                    Console.Clear();                      // Clear the console screen and display the complete scripture, including the reference and the text.
                    scripture.HideWords(hideNumber);      // Hides more words
                }
                else
                {
                    Console.WriteLine("Sorry, that is not a valid input. Please try again.");
                }
            }
        }
    }
}