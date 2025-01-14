using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string gradeInput = Console.ReadLine();
        int grade = int.Parse(gradeInput);
        if (grade >= 90)
        {
            Console.WriteLine("You have an A");
        }
        else if (grade >= 80 && grade < 90)
        {
            Console.WriteLine("You have a B");
        }
        else if (grade >= 70 && grade < 80)
        {
            Console.WriteLine("You have a C");
        }
        else if (grade >= 60 && grade < 70)
        {
            Console.WriteLine("You have a D");
        }
        else
        {
            Console.WriteLine("You have an F");
        }
        if (grade >= 70)
        {
            Console.WriteLine("Congradulations! You are passing!");
        }
    }
}