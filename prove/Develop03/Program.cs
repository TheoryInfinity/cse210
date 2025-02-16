using System;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> _scriptures = new List<Scripture>();
        
        //Add some intial scriptures
        _scriptures.Add(new Scripture("John 3:16", 
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
        
        _scriptures.Add(new Scripture("Proverbs 3:5-6", 
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding.\nIn all thy ways acknowledge him, and he shall direct thy paths."));
        
        _scriptures.Add(new Scripture("Philippians 4:13", 
            "I can do all things through Christ which strengtheneth me."));

        // Display menu for getting a scripture selection
        Console.Clear();
        Console.WriteLine("Select a scripture to memorize:");
        for (int i = 0; i < _scriptures.Count; i++)
        {
            Console.WriteLine($"\n{i + 1}. ");
            _scriptures[i].Display();
        }

        int selection;
        do
        {
            Console.Write("\nEnter selection (1-3): ");
        } while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > _scriptures.Count);

        Scripture selectedScripture = _scriptures[selection - 1];

        // Main memorization for the program
        bool done = false;
        while(!done) {
            Console.Clear();
            selectedScripture.Display();
            
            if (selectedScripture.IsFinished())
            {
                done = true;
                continue;
            }

            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();
            
            if (input.ToLower() == "quit")
            {
                done = true;
            }
            else if (!selectedScripture.HideVerse())
            {
                done = true;
            }
        }
    }
}