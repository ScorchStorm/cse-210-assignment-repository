using Newtonsoft.Json;
class Quest
{
    [JsonProperty]
    private int score;
    [JsonProperty]
    private List<Goal> goals = new List<Goal>();
    public Quest() {}

    public void DisplayGoals()
    {
        Console.WriteLine("Your Goals:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine($"{goal.GetCheckBox()} {goal.GetName()}: {goal.GetEarnedPoints()} points");
        }
    }

    public void Welcome()
    {
        Console.WriteLine("Welcome to the Eternal Quest program!");
    }
    public void CreateNewGoals()
    {
        // [JsonProperty]
        List<string> options = new List<string>{"Simple Goal", "Eternal Goal", "Checklist Goal"};
        // [JsonProperty]
        Choice choice = new Choice("Please enter the index of the type of goal you would like to create", options);
        // [JsonProperty]
        int index = choice.MakeChoice();
        Console.WriteLine("What would you like the name of your goal to be? ");
        // [JsonProperty]
        string newName = Console.ReadLine();
        Console.WriteLine("How many points would you like your goal to be worth? ");
        // [JsonProperty]
        int newPoints = int.Parse(Console.ReadLine());
        if (index == 1)
        {
            // [JsonProperty]
            // Console.WriteLine($"newPoints = {newPoints}");
            SimpleGoal newGoal = new SimpleGoal(newPoints, newName);
            // Console.WriteLine($"newGoal.GetPoints() = {newGoal.GetPoints()}");
            goals.Add(newGoal);
            // Console.WriteLine($"goals[0].GetPoints() = {goals[0].GetPoints()}");
        }
        else if (index == 2)
        {
            // [JsonProperty]
            EternalGoal newGoal = new EternalGoal(newPoints, newName);
            goals.Add(newGoal);
        }
        else if (index == 3)
        {
            Console.WriteLine("How many times would you like this goal to be completed? ");
            // [JsonProperty]
            int nCompletionsGoal = int.Parse(Console.ReadLine());
            Console.WriteLine("How many bonus points would you like to receive from completing this goal? ");
            // [JsonProperty]
            int bonusPoints = int.Parse(Console.ReadLine());
            // [JsonProperty]
            ChecklistGoal newGoal = new ChecklistGoal(newPoints, newName, nCompletionsGoal, bonusPoints);
            goals.Add(newGoal);
        }
    }

    public void DisplayScore()
    {
        score = 0;
        foreach (Goal goal in goals)
        {
            score += goal.GetEarnedPoints();
        }
        Console.WriteLine("Your score is " + score);
    }

    public void RecordEvent()
    {
        Console.WriteLine();
        List<string> options = new List<string>();
        foreach (Goal goal in goals)
        {
            options.Add(goal.GetName());
        }
        Choice choice = new Choice("Please enter the index of the goal you completed?", options);
        int index = choice.MakeChoice();
        goals[index-1].MarkCompleted();
    }
}