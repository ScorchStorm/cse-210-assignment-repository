class Menu
{
    Journal j = new Journal();
    int i;
    public Menu() // Provide a menu that allows the user choose from some options
    {
        while (true)
        {
            Console.WriteLine("Welcome to the journal program! To continue, enter the index of one of the following options:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Close the program");
            i = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                j.WriteNewEntry(); // Write a new entry - Show the user a random prompt (from a list that you create), and save their response, the prompt, and the date as an Entry.
            }
            else if (i == 2)
            {
                j.DislayJournal(); // Display the journal - Iterate through all entries in the journal and display them to the screen.
            }
            else if (i == 3)
            {
                j.SaveJournal(); // Save the journal to a file - Prompt the user for a filename and then save the current journal (the complete list of entries) to that file location.
            }
            else if (i == 4)
            {
                j.LoadJournal(); // Load the journal from a file - Prompt the user for a filename and then load the journal (a complete list of entries) from that file. This should replace any entries currently stored the journal.
            }
            else if (i == 5)
            {
                break; // Closes the program
            }
        }
    }
}