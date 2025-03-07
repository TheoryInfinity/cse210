using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Blue", 3);
        // double currentArea = square.GetArea();
        // string currentColor = square.GetColor();
        // Console.WriteLine("Square");
        // Console.WriteLine($"Area: {currentArea}");
        // Console.WriteLine($"Color: {currentColor}\n");

        
        Rectangle rectangle = new Rectangle("Green", 3, 5);
        // currentArea = rectangle.GetArea();
        // currentColor = rectangle.GetColor();
        // Console.WriteLine("Rectangle");
        // Console.WriteLine($"Area: {currentArea}");
        // Console.WriteLine($"Color: {currentColor}\n");

        Circle circle = new Circle("Purple", 4);
        // currentArea = circle.GetArea();
        // currentColor = circle.GetColor();
        // Console.WriteLine("Circle");
        // Console.WriteLine($"Area: {currentArea}");
        // Console.WriteLine($"Color: {currentColor}\n");


        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes) {
            string currentColor = shape.GetColor();
            double currentArea = shape.GetArea();
            Console.WriteLine($"Area: {currentArea}");
            Console.WriteLine($"Color: {currentColor}\n");
        } 

    }
}