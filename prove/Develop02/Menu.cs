class Menu
{
    Journal _j = new Journal();
    int _i;
    public Menu() // Provide a menu that allows the user choose from some options
    {
        Console.WriteLine("Welcome to the journal program!");
        while (true)
        {
            Console.WriteLine("To continue, enter the index of one of the following options:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Close the program");
            _i = int.Parse(Console.ReadLine());
            if (_i == 1)
            {
                _j.WriteNewEntry(); // Write a new entry - Show the user a random prompt (from a list that you create), and save their response, the prompt, and the date as an Entry.
            }
            else if (_i == 2)
            {
                _j.DislayJournal(); // Display the journal - Iterate through all entries in the journal and display them to the screen.
            }
            else if (_i == 3)
            {
                _j.SaveJournal(); // Save the journal to a file - Prompt the user for a filename and then save the current journal (the complete list of entries) to that file location.
            }
            else if (_i == 4)
            {
                _j.LoadJournal(); // Load the journal from a file - Prompt the user for a filename and then load the journal (a complete list of entries) from that file. This should replace any entries currently stored the journal.
            }
            else if (_i == 5)
            {
                break; // Closes the program
            }
        }
    }
}