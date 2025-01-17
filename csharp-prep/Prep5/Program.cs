using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string username = PromptUserName();
        int favoriteNumber = PromptUserNumbers();
        int numberSquared = SquareNumber(favoriteNumber);
        DisplayResults(username, numberSquared);

    }

    static void DisplayWelcome() {
    Console.WriteLine("Welcome!");
    }

    static string PromptUserName() {
        Console.Write("Please enter your username:");
        string Username = Console.ReadLine();
        return Username;
    }

    static int PromptUserNumbers() {
        Console.Write("Please enter your favorite number:");
        string favoriteInput = Console.ReadLine();
        int favoriteNumber = Convert.ToInt32(favoriteInput);
        return favoriteNumber;
    }

    static int SquareNumber(int number) {
        int numberSquared = number * number;
        return numberSquared;
    }

    static void DisplayResults(string username, int number) {
            Console.WriteLine($"Your username is {username}.");
            Console.WriteLine($"Your favorite number squared is {number}.");
    }
}