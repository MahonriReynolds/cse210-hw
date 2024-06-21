
public class ChecklistGoal:Goal
{
    private int _iterations;
    private int _progress;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int iterations, int bonus, int progress=0)
    : base(name, description, points)
    {
        this._iterations = iterations;
        this._progress = progress;
        this._bonus = bonus;
    }

    public override void Complete()
    {
        this._progress++;
        if (this._progress > this._iterations)
        {
            this._progress = 1;
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

    public override string ToStorage()
    {
        return $"ChecklistGoal|{base.ToStorage()}|{this._iterations}|{this._bonus}|{this._progress}";
    }

    public override string ToString()
    {
        if (this._progress >= this._iterations)
        {
            return $"[X] {base.ToString()} -- {this._progress}/{this._iterations} to {this._bonus} bonus points";
        }
        return $"[ ] {base.ToString()} -- {this._progress}/{this._iterations} to {this._bonus} bonus points";
        
    }
}


