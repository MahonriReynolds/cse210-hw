


public class Assignment
{
    private string _name;
    private string _topic;

    public Assignment(string name, string topic)
    {
        this._name = name;
        this._topic = topic;
    }

    public string GetName()
    {
        return this._name;
    }

    public string GetSummary()
    {
        return $"{this._name} - {this._topic}";
    }
}