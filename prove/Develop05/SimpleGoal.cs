
public class SimpleGoal:Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points)
    : base(name, description, points)
    {
        this._completed = false;
    }

    public override void Complete()
    {
        this._completed = true;
    }

    public override string ToStorage()
    {
        return $"SimpleGoal|{base.ToStorage()}";
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


