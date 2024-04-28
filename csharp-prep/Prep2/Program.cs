using System;

class Program
{
    static void Main(string[] args)
    {
        string letter;
        string sign;
        Console.Write("What is your grade percentage? ");
        string percentageString = Console.ReadLine();
        int percentage = int.Parse(percentageString);
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        if (percentage%10 <= 3)
        {
            sign = "-";
        }
        else if (percentage%10 >= 7)
        {
            sign = "+";
        }
        else
        {
            sign = "";
        }
        if (letter == "A" && sign == "+" || letter == "F")
        {
            sign = "";
        }
        Console.WriteLine($"Your grade is a {letter}{sign}.");
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass the class. You can pass the class if you take it again and try harder.");
        }
    }
}