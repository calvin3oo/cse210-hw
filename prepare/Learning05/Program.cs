using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("red", 5));
        shapes.Add(new Rectangle("red", 3, 5));
        shapes.Add(new Circle("red", 5));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine("Area: " + shape.GetArea().ToString() + " Color: " + shape.GetColor());
        }
    }
}