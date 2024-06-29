using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

public class GoalConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return (objectType == typeof(Goal));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JObject jo = JObject.Load(reader);

        string goalType = jo["goalType"]?.ToString();
        Goal goal;

        switch (goalType)
        {
            case "simple":
                goal = new SimpleGoal(
                    (int)jo["points"],
                    jo["name"]?.ToString()
                );
                break;
            case "eternal":
                goal = new EternalGoal(
                    (int)jo["points"],
                    jo["name"]?.ToString()
                );
                break;
            case "checklist":
                goal = new ChecklistGoal(
                    (int)jo["points"],
                    jo["name"]?.ToString(),
                    (int)jo["nCompletionsGoal"],
                    (int)jo["bonusPoints"]
                );
                break;
            default:
                throw new Exception("Unknown occupation type.");
        }

        serializer.Populate(jo.CreateReader(), goal);
        return goal;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        JObject jo = new JObject();
        var goal = value as Goal;
        if (goal != null)
        {
            jo.Add("name", goal.GetName());
            jo.Add("points", goal.GetPoints());
            jo.Add("goalType", goal.GetGoalType());
            jo.Add("timesCompleted", goal.GetTimesCompleted());

            if (value is SimpleGoal simpleGoal) {}
            
            if (value is EternalGoal eternalGoal) {}

            else if (value is ChecklistGoal checklistGoal)
            {
                jo.Add("nCompletionsGoal", checklistGoal.GetNCompletionsGoal());
                jo.Add("bonusPoints", checklistGoal.GetBonusPoints());
            }
        }
        jo.WriteTo(writer);
    }
}
