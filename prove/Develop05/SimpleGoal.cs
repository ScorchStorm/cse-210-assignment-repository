using Newtonsoft.Json;
class SimpleGoal : Goal
{
    public SimpleGoal(int points, string name) : base(points, name, "simple") {}

    public override void MarkCompleted()
    {
        if (timesCompleted == 0)
        {
            base.MarkCompleted();
        }
    }
}