
public abstract class Shape
{
    private string _color;


    public string GetColor()
    {
        return this._color;
    }

    public void SetColor(string color)
    {
        this._color = color;
    }

    public abstract double GetArea();
}


