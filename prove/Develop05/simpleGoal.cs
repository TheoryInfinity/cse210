using System.Runtime.CompilerServices;

public class SimpleGoal : Goal {

    private bool _completed;

    public SimpleGoal() : base {
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
        string representation = $"SimpleGoal:|:{_name}:|:{_pointValue}:|:{_desc}:|:";
        return representation;
    }

    public override bool IsCompleted()
    {
        return _completed;
    }

    public override void SetCompleted()
    {
        base.SetCompleted();
    }

}