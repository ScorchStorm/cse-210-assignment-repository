using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapesList = new List<Shape>();
        Square square = new Square("blue", 2);
        shapesList.Add(square);
        Rectangle rectangle = new Rectangle("green", 1, 2);
        shapesList.Add(rectangle);
        Circle circle = new Circle("red", 2);
        shapesList.Add(circle);
        List<string> shapeNames = new List<string>{"square", "rectangle", "circle"};
        for (int i = 0; i < shapesList.Count; i++)
        {
            Console.WriteLine();
            Console.WriteLine($"shape type: {shapeNames[i]}");
            Console.WriteLine($"shape color: {shapesList[i].GetColor()}");
            Console.WriteLine($"shape area: {shapesList[i].GetArea()}");
        }
    }
}