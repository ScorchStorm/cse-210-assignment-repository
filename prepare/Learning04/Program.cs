using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Samuel Bennett",  "Multiplication");
        string summary = assignment.GetSummary();
        Console.WriteLine(summary);
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        summary = mathAssignment.GetSummary();
        Console.WriteLine(summary);
        string homeworkList = mathAssignment.GetHomeworkList();
        Console.WriteLine(homeworkList);
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        summary = writingAssignment.GetSummary();
        Console.WriteLine(summary);
        string writingInformation = writingAssignment.GetWritingInformation();
        Console.WriteLine(writingInformation);
    }
}