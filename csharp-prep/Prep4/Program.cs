using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers =  new List<int>();
        
        bool done = false;

        Console.WriteLine("Choose integers to add to the list. If finished, type 0.");
        while (!done) {
            Console.Write("Enter Number: ");
            string addedString = Console.ReadLine();
            int addedNumber = Convert.ToInt32(addedString);
            if (addedNumber != 0)
                numbers.Add(addedNumber);
            else
                done = true;
            
        }

        int numbersSum = ComputeSum(numbers);
        Console.WriteLine($"Your total is {numbersSum}");

        double numbersAverage = ComputeAverage(numbers);
        Console.WriteLine($"Your mean is {numbersAverage}");

        int numbersMaximum = ComputeMaximum(numbers);
        Console.WriteLine($"Your Highest number is {numbersMaximum}");

    }

    static int ComputeSum(List<int> numbers) {
        int sum = 0;
            foreach (int number in numbers) {
                sum += number;
            }
        return sum;
    }

    static double ComputeAverage(List<int> numbers) {

        int total = ComputeSum(numbers);
        double Average = total / numbers.Count;

        return Average;
    }

    static int ComputeMaximum(List<int> numbers) {
        int highest = 0;
        
        foreach (int number in numbers) {
            if (number > highest) {
                highest = number;
            }
        }

        return highest;
    }

}