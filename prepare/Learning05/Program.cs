using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = [];
        shapes.Add(new Square("red", 5.07));
        shapes.Add(new Rectangle("blue", 5.07, 8.34));
        shapes.Add(new Circle("green", 8.34));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape} - Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}