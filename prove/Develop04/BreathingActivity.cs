public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string desc)
    {
        _name = name;
        _desc = desc;
    }

    public void Animation()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        // Added a seperate custome breathing animation for breathing
        string animation = "▒▒▒▒▒▓";
        bool inside = true;

        while (startTime < endTime)
        {
            int counter = 5;
            if (inside)
            {
                Console.WriteLine("Breath in...");
                animation = "▓▓▓▓▓▒";
            }
            else
            {
                animation = "░░░░░▒";
                Console.WriteLine("Breath out...");
            }

            foreach (char character in animation)
            {
                Console.Write($"   {character}{character}{character}{character}{character}");
                if (character == Convert.ToChar("▒"))
                {
                    inside = !inside;
                    Console.WriteLine("\n   Hold ");
                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine($"\n     {counter}   ");
                    counter--;
                    Thread.Sleep(1000);
                }

                Console.SetCursorPosition(0, Console.CursorTop - 2);
            }
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            startTime = DateTime.Now;
        }
    }

    public void Start()
    {
        Console.WriteLine("");
        Console.WriteLine(_name);
        Console.WriteLine(_desc);
        AskDuration();
        GetReady(5);
        Animation();
        DisplayWellDone();
    }
}