

public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius)
    {
        base.SetColor(color);
        this._radius = radius;
    }

    public override double GetArea()
    {
        return this._radius * this._radius * Math.PI;
    }
}