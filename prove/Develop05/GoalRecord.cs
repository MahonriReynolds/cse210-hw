using System.Text.Json;


public class GoalRecord
{
    
    public List<Goal> GetGoals(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        List<Goal> goalList = [];
        foreach (string line in lines)
        {
            Goal newGoal = BuildGoal(line);
            goalList.Add(newGoal);
        }
        return goalList;
    }

    private Goal BuildGoal(string goalString)
    {
        var jsonDoc = JsonDocument.Parse(goalString);
        var root = jsonDoc.RootElement;
        
        if (root.TryGetProperty("_type", out JsonElement typeElement))
        {
            string type = typeElement.GetString();
            switch (type)
            {
                case "SimpleGoal":
                    return JsonSerializer.Deserialize<SimpleGoal>(goalString);
                case "EternalGoal":
                    return JsonSerializer.Deserialize<EternalGoal>(goalString);
                case "ChecklistGoal":
                    return JsonSerializer.Deserialize<ChecklistGoal>(goalString);
            }
        }
        return new EternalGoal("", "", 0);
    }

    
}

