using System;

class Program
{
    static void Main(string[] args)
    {
        Choice choice = new Choice("Which Activity would you like to complete?", new List<string>{"Breathing Activity", "Reflection Activity", "Listing Activity"});
        int ind = choice.MakeChoice();
        if (ind == 0)
        {
            BreathingActivity activity = new BreathingActivity();
            activity.PrintMessage();
            activity.RunActivity();
            activity.CongratulateUser();
        }
        else if (ind == 1)
        {
            ReflectionActivity activity = new ReflectionActivity();
            activity.PrintMessage();
            activity.RunActivity();
            activity.CongratulateUser();
        }
        else if (ind == 2)
        {
            ListingActivity activity = new ListingActivity();
            activity.PrintMessage();
            activity.RunActivity();
            activity.CongratulateUser();
        }
    }
}