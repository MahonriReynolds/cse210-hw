using System.Text.Json.Serialization;

public class EternalGoal:Goal
{
    [JsonInclude]
    private string _type;

    public EternalGoal(string name, string description, int points)
    : base(name, description, points)
    {
        this._type = "EternalGoal";
    }

    public override string ToString()
    {
        return $"[-] {base.ToString()}";
    }

}

