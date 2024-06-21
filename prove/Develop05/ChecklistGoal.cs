
public class ChecklistGoal:Goal
{
    private int _iterations;
    private int _progress;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int iterations, int bonus)
    : base(name, description, points)
    {
        this._iterations = iterations;
        this._progress = 0;
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

    public override string StringStorage()
    {
        return $"ChecklistGoal|{base.ToString()}|{this._iterations}|{this._bonus}";
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


