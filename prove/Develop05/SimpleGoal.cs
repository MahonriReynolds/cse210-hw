
public class SimpleGoal:Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points, bool completed=false)
    : base(name, description, points)
    {
        this._completed = completed;
    }

    public override int CheckOff()
    {
        if (!_completed)
        {
            this._completed = true;
            return base.CheckOff();
        }
        this._completed = true;
        return 0;
    }

    public override string ToStorage()
    {
        return $"SimpleGoal|{base.ToStorage()}|{this._completed}";
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


