using System.ComponentModel.DataAnnotations;

public class ChecklistGoal : Goal
{

    private int _bonusPoints;
    private int _timesCompleted;
    private int _timesUntilComplete;

    public ChecklistGoal() : base()
    {
        _bonusPoints = 0;
        _timesCompleted = 0;
        _timesUntilComplete = 0;
    }

    public ChecklistGoal(int points, string name, string description, int bonus, int times) : base(points, name, description)
    {
        _bonusPoints = bonus;
        _timesCompleted = 0;
        _timesUntilComplete = times;
    }

    public override void Display()
    {
        if (_timesCompleted >= _timesUntilComplete)
        {
            Console.Write("[X] ");
        }
        else
        {
            Console.Write("[ ] ");
        }
        Console.WriteLine($"{_name}: {_pointValue} Points");
        Console.WriteLine(_desc);
        Console.WriteLine($"{_timesCompleted}/{_timesUntilComplete}");
    }

    public override string GetRep()
    {
        string representation = $"ChecklistGoal:|:{_pointValue}:|:{_name}:|:{_desc}:|:{_bonusPoints}:|:{_timesUntilComplete}:|:{_timesCompleted}";
        return representation;
    }

    public override int IsCompleted()
    {
        _timesCompleted++;
        if (_timesCompleted == _timesUntilComplete)
        {
            return _pointValue + _bonusPoints;
        }
        else
        {
            return _pointValue;
        }
    }

    public ChecklistGoal(int points, string name, string description, int bonus, int times, int timescompleted) : base(points, name, description)
    {
        _bonusPoints = bonus;
        _timesCompleted = timescompleted;
        _timesUntilComplete = times;
    }

}