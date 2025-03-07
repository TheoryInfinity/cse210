public class ListingActivity : Activity {
    private List<string> _prompts = new List<string>();
    private List<string> _items = new List<string>();
    Random rand = new Random();
    public ListingActivity(string name, string desc)
    {
        _name = name;
        _desc = desc;

        _prompts = new List<string>{
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
        };     
        
         _items = new List<string>{
            // empty List just in case
         };
    }

    public void Listing() {
        int rando;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        int counter = 5;
        
        
            Console.WriteLine("");
            rando = rand.Next(_prompts.Count);
            Console.WriteLine(_prompts[rando]);
            Console.WriteLine("");
            Console.WriteLine("Take a moment to think about the prompt");

        while (startTime < endTime)
        {
            
            while (counter >= 0) {
                Console.WriteLine($"\n     {counter}   ");
                Console.SetCursorPosition(0, Console.CursorTop - 2);
                counter--;
                Thread.Sleep(1000);
            }

            Console.WriteLine("Type your thoughts:");
            string userInput = Console.ReadLine();
            _items.Add(userInput);

            Console.WriteLine("");
            Console.WriteLine(_items.Count);

            startTime = DateTime.Now;
        }
    }

    public void Start() {
        Console.WriteLine("");
        Console.WriteLine(_name);
        Console.WriteLine(_desc);
        AskDuration();
        GetReady(5);
        Listing();
        DisplayWellDone();
    }

}