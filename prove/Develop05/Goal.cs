using System.Text.Json.Serialization;

public abstract class Goal
{
    [JsonInclude]
    private string _name;
    [JsonInclude]
    private string _description;
    [JsonInclude]
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

    public override string ToString()
    {
        return $"{this._name} ({this._description})";
    }
}


