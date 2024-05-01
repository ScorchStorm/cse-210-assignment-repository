using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squareNumber = SquareNumber(userNumber);
        DisplayResult(userName, squareNumber);
    }
    static void DisplayWelcome() // Displays the message, "Welcome to the Program!"
    {
        Console.WriteLine("Welcome to the Program!");
    }
        
    static string PromptUserName() // Asks for and returns the user's name (as a string)
    {
        Console.Write("Please enter your name: ");
        string Username = Console.ReadLine();
        return Username;
    }
    static int PromptUserNumber() // Asks for and returns the user's favorite number (as an integer)
    {
        Console.Write("Please enter your favorite number: ");
        int userNumber = int.Parse(Console.ReadLine());
        return userNumber;
    }  
    static int SquareNumber(int userNumber) // Accepts an integer as a parameter and returns that number squared (as an integer)
    {
        return userNumber*userNumber;
    }
    static void DisplayResult(string userName, int squareNumber) // Accepts the user's name and the squared number and displays them.
    {
        Console.WriteLine($"{userName}, the square of your number is {squareNumber}");
    }
}