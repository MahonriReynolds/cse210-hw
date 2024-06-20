
public class EternalGoal:Goal
{

    public EternalGoal(string name, string description, int points)
    : base(name, description, points)
    {
    }

    public override string StringStorage()
    {
        return $"EternalGoal|{base.ToString()}";
    }

    public override string ToString()
    {
        return $"[-] {base.ToString()}";
    }

}

