using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 10);

        bool done = false;

        int guess = 0;

        while (done != true) {
            Console.WriteLine($"What is your guess?");
            string guessInput = Console.ReadLine();
            guess = Convert.ToInt32(guessInput);
            if (guess > magicNumber) {
                Console.WriteLine("Guess Lower");
            } else if (guess < magicNumber )
            {
                Console.WriteLine("Guess Higher");
            } else {
                Console.WriteLine("Correct! You Guessed it!");
                done = true;
            }
        }

    }
}