using System.Runtime.CompilerServices;

public class SimpleGoal : Goal {

    private bool _completed;

    public SimpleGoal() : base() {
        _completed = false;
    }

    public SimpleGoal(int points, string name, string description) : base (points, name, description) {
        _completed = false;
    }

    public override void Display()
    {
        Console.WriteLine($"{_name}: {_pointValue} Points ");
        if (_completed) {
            Console.Write("[X]");
        }
        else {
            Console.Write("[ ]");
        }
        Console.WriteLine(_desc);
    }

    public override string GetRep()
    {
        string representation = $"SimpleGoal:|:{_name}:|:{_pointValue}:|:{_desc}:|:{_completed}";
        return representation;
    }

    public override int IsCompleted()
    {
        SetCompleted();
;       return _pointValue;
    }

    public override void SetCompleted()
    {
        base.SetCompleted();
        _completed = true;
    }
    public SimpleGoal(int points, string name, string description, bool completed) : base (points, name, description) {
        _completed = completed;
    }
}