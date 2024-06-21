
public class EternalGoal:Goal
{

    public EternalGoal(string name, string description, int points)
    : base(name, description, points)
    {
    }

    public override string ToStorage()
    {
        return $"EternalGoal|{base.ToStorage()}";
    }

    public override string ToString()
    {
        return $"[-] {base.ToString()}";
    }

}

