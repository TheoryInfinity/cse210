using System;

class Program
{
    static void Main(string[] args)
    {
        // ***** 1/1 or 1
        Fraction fraction = new Fraction(1);
        
        string exact = fraction.GetFractionString();
        double approximate = fraction.GetDecimalValue();
        Console.WriteLine($"{exact}");
        Console.WriteLine($"{approximate}");

        // ***** 5/1 or 5
        fraction.SetNumerator(5);
        
        exact = fraction.GetFractionString();
        approximate = fraction.GetDecimalValue();
        Console.WriteLine($"{exact}");
        Console.WriteLine($"{approximate}");

        // ***** 3/4 or 0.75
        Fraction fraction2 = new Fraction();
        fraction2.SetNumerator(3);
        fraction2.SetDenominator(4);
        
        exact = fraction2.GetFractionString();
        approximate = fraction2.GetDecimalValue();
        Console.WriteLine($"{exact}");
        Console.WriteLine($"{approximate}");

        // ***** 1/ 3 or 0.33333333333
        Fraction fraction3 = new Fraction(1, 3);

        exact = fraction3.GetFractionString();
        approximate = fraction3.GetDecimalValue();
        Console.WriteLine($"{exact}");
        Console.WriteLine($"{approximate}");

    }
}