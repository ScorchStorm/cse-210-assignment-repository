using Newtonsoft.Json;
[JsonConverter(typeof(GoalConverter))]

class Goal
{
    [JsonProperty]
    protected string name;
    [JsonProperty]
    protected int points;
    [JsonProperty]
    protected int timesCompleted;
    [JsonProperty]
    protected string goalType;
    public Goal(int points, string name, string goalType)
    {
        this.name = name;
        this.points = points;
        this.goalType = goalType;
        this.timesCompleted = 0;
    }

    public virtual void MarkCompleted()
    {
        timesCompleted += 1;
    }

    public int GetPoints()
    {
        return points;
    }

    public virtual int GetEarnedPoints()
    {
        return points * timesCompleted;
    }

    public string GetCheckBox()
    {
        if (timesCompleted == 0)
        {
            return "[ ]  ";
        }
        else if (timesCompleted == 1)
        {
            // return "[✔]  ";
            return "[✓]  ";
        }
        else
        {
            // return $"[✔]x{timesCompleted}";
            return $"[✓]x{timesCompleted}";
        }
    }

    public string GetName()
    {
        return name;
    }

    public int GetTimesCompleted()
    {
        return timesCompleted;
    }

    public string GetGoalType()
    {
        return goalType;
    }
}