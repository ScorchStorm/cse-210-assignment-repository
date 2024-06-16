using System;

abstract class Activity
{
    private string message;
    protected int time;
    private string name;
    public Activity(string name, string message)
    {
        this.name = name;
        this.message = message;
    }

    public float PrintMessage()
    {
        Console.WriteLine(name);
        Console.WriteLine(message);
        Console.WriteLine("How many seconds would you like to do this activity for? ");
        time = int.Parse(Console.ReadLine());
        return time;
    }

    public abstract void RunActivity();

    public void DelayAnimation(int delayTime)
    {
        int runTime = 0;
        while (delayTime > runTime)
        {
            Console.Write("\b \b"); // Erase the + character
            Console.Write(@"\");
            Thread.Sleep(250);
            Console.Write("\b \b"); // Erase the + character
            Console.Write('|');
            Thread.Sleep(250);
            Console.Write("\b \b"); // Erase the + character
            Console.Write('/');
            Thread.Sleep(250);
            Console.Write("\b \b"); // Erase the + character
            Console.Write(" -");
            Thread.Sleep(250);
            runTime++;
        }
        Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
    }

    public float GetTime()
    {
        return time;
    }

    public void CongratulateUser()
    {
        Console.WriteLine($"Congratulations on finishing the {name}!");
    }
}