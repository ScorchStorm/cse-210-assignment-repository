using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number? ");
        int number = int.Parse(Console.ReadLine());
        int guess = 0;
        int nGuesses = 0;
        while (guess!=number)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            nGuesses++;
            if (number == guess)
            {
                Console.WriteLine("You guessed it!");
            }
            else if (number>guess)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }
        }
        Console.WriteLine($"You made {nGuesses} guesses");
        Console.Write("Do you want to play again? ");
        string playAgainString = Console.ReadLine().ToLower();
        bool ifAgain = playAgainString == "yes" || playAgainString == "true" || playAgainString == "y";
        if (ifAgain)
        {
            Main(args);
        }
    }
}