

public class Rectangle : Shape
{
    private double _length;
    private double _width;

    public Rectangle(string color, double length, double width)
    {
        base.SetColor(color);
        this._length = length;
        this._width = width;
    }

    public override double GetArea()
    {
        return this._length * this._width;
    }
}


