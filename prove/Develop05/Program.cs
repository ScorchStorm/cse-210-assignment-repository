using System;
using Newtonsoft.Json;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Quest quest;
        quest = new Quest();
        quest.Welcome();
        string prompt = "Please choose one of the following options";
        List<string> options = new List<string>{"Display Goals", "Create New Goals", "Display Score", "Record Event", "Save Goals", "Load Goals", "End Program"};
        Choice choice = new Choice(prompt, options);
        while (true)
        {
            Console.WriteLine("");
            int integer = choice.MakeChoice();
            if (integer == 1)
            {
                quest.DisplayGoals();
            }
            else if (integer == 2)
            {
                quest.CreateNewGoals();
            }
            else if (integer == 3)
            {
                quest.DisplayScore();
            }
            else if (integer == 4)
            {
                quest.RecordEvent();
            }
            else if (integer == 5)
            {
                string json = JsonConvert.SerializeObject(quest);
                File.WriteAllText("quest.json", json);
            }
            else if (integer == 6)
            {
                Console.WriteLine("Deserialized Quest");
                Console.WriteLine("-------------------");
                string json = File.ReadAllText("quest.json");
                quest = JsonConvert.DeserializeObject<Quest>(json);
            }
            else if (integer == 7)
            {
                Environment.Exit(0);
            }
        }
    }
}