public class Activity
{
    protected string _name;
    protected string _desc;
    protected int _duration;

    public Activity()
    {
        _name = "Blank";
        _desc = "Blank";
        _duration = 0;
    }

    public Activity(string name, string desc)
    {
        _name = name;
        _desc = desc;
    }

    public void SetDuration(int time)
    {
        _duration = time;
    }

    public string GetName()
    {
        return _name;
    }
    public string GetDesc() {
        return _desc;
    }
    public void AskDuration()
    {
        try
        {
            Console.WriteLine("Please enter a duration.");
            _duration = Convert.ToInt32(Console.ReadLine());

            if (_duration <= 1)
            {
                Console.WriteLine("Give yourself more than a second");
                AskDuration();
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            AskDuration();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public void LoadingAnimation(int time)
    {
        DateTime currentTime = DateTime.Now;
        DateTime endTime = currentTime.AddSeconds(time);

        string animation = "░░░▒░▒▒▓▓▒▒░▒░░░";

        while (currentTime < endTime)
        {
            for (int i = 0; i < animation.Length; i++)
            {
                Thread.Sleep(75);
                string shiftedAnimation = animation.Substring(animation.Length - i) + animation.Substring(0, animation.Length - i);
                Console.WriteLine(shiftedAnimation);
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
            currentTime = DateTime.Now;
        }
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.WriteLine("                    ");
        Console.WriteLine("                    ");
        Console.SetCursorPosition(0, Console.CursorTop - 1);
    }


    public void GetReady(int time)
    {
        Console.WriteLine("Get Ready!");
        LoadingAnimation(time);
    }

    public void DisplayWellDone()
    {
        Console.WriteLine("Well Done!");
        Console.WriteLine("                    ");
        LoadingAnimation(5);
        Console.WriteLine($"You completed:  {_name}");
        Console.WriteLine($"Time Elapsed:  {_duration}");
    }

    // Funciton ideas: 
    // Display Timer
    // End activity


    // Animation Ideas:
    // "░░▒▓▓▒░░"
    // "◌○೦◯೦○◌"


}