

public class Item
{
    private string _name;
    private string _description;
    private string _model;

    public Item(string name, string description, string model)
    {
        this._name = name;
        this._description = description;
        this._model = model;
    }

    public string Describe()
    {
        return $"{this._name} ~ {this._description}";
    }

    public override string ToString()
    {
        return this._model;
    }
}