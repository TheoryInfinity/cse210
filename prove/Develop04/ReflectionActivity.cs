public class ReflectionActivity : Activity {
    private List<string> _prompts = new List<string>();

    private List<string> _questions = new List<string>();
    Random rand = new Random();

    public ReflectionActivity(string name, string desc)
    {
        _name = name;
        _desc = desc;

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Reflect() {
        int rando;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        

        Console.WriteLine("");
        rando = rand.Next(_prompts.Count);
        Console.WriteLine(_prompts[rando]);
        Console.WriteLine("");

        while (startTime < endTime && _questions.Count > 1)
        {
            rando = rand.Next(_questions.Count);
            Console.WriteLine(_questions[rando]);
            _questions.RemoveAt(rando);
            
            TimeSpan remainingTime = endTime - DateTime.Now;
            int loadingTime = (int)Math.Min(10, remainingTime.TotalSeconds);

            Console.WriteLine("");
            LoadingAnimation(loadingTime);
            startTime = DateTime.Now;
        }
    }

    public void Start() {
        Console.WriteLine("");
        Console.WriteLine(_name);
        Console.WriteLine(_desc);
        AskDuration();
        GetReady(5);
        Reflect();
        DisplayWellDone();
    }

}