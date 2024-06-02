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
        Scripture scripture = SelectScripture(scriptures);      // Prompts the User to select the index of a scripture
        // Console.WriteLine("0.");
        scripture.ShowWords();
        SelectHiddenType(scripture);                           // Prompts the User to select whether they want hidden words to show the first letter or not
        // Console.WriteLine("1.");
        // scripture.ShowWords();
        Prompt(scripture);                                      // Prompt the user to press the enter key or type quit.
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
        string prompt = "Enter the index of the scripture you would like to load.";
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
        // Console.WriteLine("2.");
        // scripture.ShowWords();
        int hideNumber = 8; // The number of additional words to hide each time the enter key is pressed
        // Console.WriteLine("2.5");
        // scripture.ShowWords();
        while (true)
        {
            Console.WriteLine("3.");
            scripture.ShowWords();
            Console.WriteLine("Press Enter to hide more verses or type quit to end the program");
            string input = Console.ReadLine();
            if (input == "quit")
            {
                Environment.Exit(1);                  // Ends the program
            }
            else if (input == "")
            {
                // Console.WriteLine("4.");
                // scripture.ShowWords();
                Console.Clear();                      // Clear the console screen and display the complete scripture, including the reference and the text.
                // Console.WriteLine("5.");
                // scripture.ShowWords();
                scripture.HideWords(hideNumber);      // Hides more words
                // Console.WriteLine("6.");
                // scripture.ShowWords();
            }
            else
            {
                Console.WriteLine("Sorry, that is not a valid input. Please try again.");
            }
        }
    }
}