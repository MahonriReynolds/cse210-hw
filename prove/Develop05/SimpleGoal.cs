using System.Text.Json.Serialization;

public class SimpleGoal:Goal
{
    [JsonInclude]
    private string _type;
    [JsonInclude]
    private bool _completed;

    public SimpleGoal(string name, string description, int points)
    : base(name, description, points)
    {
        this._type = "SimpleGoal";
        this._completed = false;
    }

    public void Complete()
    {
        this._completed = true;
    }

    public override string ToString()
    {
        if (this._completed)
        {
            return $"[X] {base.ToString()}";
        }
        return $"[ ] {base.ToString()}";
        
    }
}


