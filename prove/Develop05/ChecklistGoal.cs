using Newtonsoft.Json;
class ChecklistGoal : Goal
{
    [JsonProperty]
    private int nCompletionsGoal;
    [JsonProperty]
    private int bonusPoints;
    public ChecklistGoal(int points, string name, int nCompletionsGoal, int bonusPoints) : base(points, name, "checklist")
    {
        this.nCompletionsGoal = nCompletionsGoal;
        this.bonusPoints = bonusPoints;
    }

    public override int GetEarnedPoints()
    {
        if (timesCompleted >= nCompletionsGoal)
        {
            return bonusPoints + points * timesCompleted;
        }
        else
        {
            return points * timesCompleted;
        }
    }

    public int GetNCompletionsGoal()
    {
        return nCompletionsGoal;
    }

    public int GetBonusPoints()
    {
        return bonusPoints;
    }
}