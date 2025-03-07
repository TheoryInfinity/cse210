public class Square : Shape {

    private double _side;

    public Square(string color, double sideLength) : base (color) {
        _color = color;
        _side = sideLength;
    }

    public override double GetArea()
    {
        double Area = _side * _side;
        return Area;
    }
}