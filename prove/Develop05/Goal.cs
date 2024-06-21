
public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    
    public Goal(string name, string description, int points)
    {
        this._name = name;
        this._description = description;
        this._points = points;
    }

    public virtual int Score()
    {
        return this._points;
    }

    public virtual string ToStorage()
    {
        return $"{this._name}|{this._description}|{this._points}";
    }

    public virtual void Complete()
    {

    }

    public override string ToString()
    {
        return $"{this._name}: {this._description} ({this._points} points)";
    }
}


