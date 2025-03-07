using System;

class Program
{
    static void Main(string[] args)
    {
        Activity test = new Activity();

        BreathingActivity breathing = new BreathingActivity("Core Breathing", "Breath in, hold your breath, and breath out as prompted. Clear your mind and focus on the rectangle as it fades in and out.");
        ReflectionActivity reflect = new ReflectionActivity("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        ListingActivity listing = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        bool running = true;

        while (running)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Start Breathing");
            Console.WriteLine("2. Start Listing");
            Console.WriteLine("3. Start Reflecting");
            Console.WriteLine("4. End Program");
            Console.Write("Select an option (1-4): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    breathing.Start();
                    break;
                case "2":
                    listing.Start();
                    break;
                case "3":
                    reflect.Start();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Hope this improved your day. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}