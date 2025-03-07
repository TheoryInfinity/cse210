using System.Net.NetworkInformation;

public class Circle : Shape {

    private double _radius;

    public Circle(string color,double Radius) : base (color) {
        _color = color;
        _radius = Radius;
    }

    public override double GetArea()
    {
        double Area = Math.PI * _radius * _radius;
        return Area;
    }
}