using System.Text.Json.Serialization;

public class ChecklistGoal:Goal
{
    [JsonInclude]
    private string _type;
    [JsonInclude]
    private int _iterations;
    [JsonInclude]
    private int _progress;
    [JsonInclude]
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int iterations, int bonus)
    : base(name, description, points)
    {
        this._type = "ChecklistGoal";
        this._iterations = iterations;
        this._progress = 0;
        this._bonus = bonus;
    }

    public void Complete()
    {
        this._progress++;
        if (this._progress >= this._iterations)
        {
            this._progress = this._iterations;
        }
    }

    public override int Score()
    {
        if (this._progress < this._iterations)
        {
            return base.Score();
        }
        return this._bonus;
    }

    public override string ToString()
    {
        if (this._progress >= this._iterations)
        {
            return $"[X] {base.ToString()} -- {this._progress}/{this._iterations}";
        }
        return $"[ ] {base.ToString()} -- {this._progress}/{this._iterations}";
        
    }
}


