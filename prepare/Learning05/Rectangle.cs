public class Rectangle : Shape {

    private double _length;
    private double _width;

    public Rectangle(string color, double Length, double Width) : base (color) {
        _length = Length;
        _width = Width;
    }

    public override double GetArea()
    {
        double Area = _length * _width;
        return Area;
    }
}