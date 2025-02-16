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
        
        _scriptures.Add(new Scripture("2 Nephi 9:28-29", 
            "O that cunning plan of the evil one! O the vainness, and the frailties, and the foolishness of men! When they are learned they think they are wise, and they hearken not unto the counsel of God, for they set it aside, supposing they know of themselves, wherefore, their wisdom is foolishness and it profiteth them not. And they shall perish.\nBut to be learned is good if they hearken unto the counsels of God."));

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

        // ***** Extra Content: A difficulty Selector!
        // Get difficulty selection
        Console.WriteLine("\nSelect difficulty level:");
        Console.WriteLine("1. Easy (3 words at a time)");
        Console.WriteLine("2. Medium (5 words at a time)");
        Console.WriteLine("3. Hard (7 words at a time)");

        int difficulty;
        do
        {
            Console.Write("\nEnter difficulty (1-3): ");
        } while (!int.TryParse(Console.ReadLine(), out difficulty) || difficulty < 1 || difficulty > 3);

        // Convert difficulty selection to number of words
        int wordsToHide = difficulty == 1 ? 3 : (difficulty == 2 ? 5 : 7);

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
            else if (!selectedScripture.HideVerse(wordsToHide))
            {
                done = true;
            }
        }
    }
}