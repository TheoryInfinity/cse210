
public class EternalGoal : Goal {

    private int _timesCompleted;

    public EternalGoal() : base() {
        _timesCompleted = 0;
    }

    public EternalGoal(int points, string name, string description) : base (points, name, description) {
        _timesCompleted = 0;
    }

    public override void Display() {
        Console.WriteLine($"{_name}: {_pointValue} Points");
        Console.WriteLine(_desc);
        Console.WriteLine($"{_timesCompleted}:");
    }

    public override string GetRep()
    {
        string representation = $"EternalGoal:|:{_name}:|:{_pointValue}:|:{_desc}:|:{_timesCompleted}";
        return representation;
    }

    public override int IsCompleted()
    {
        _timesCompleted++;
        return _pointValue;
    }

    public EternalGoal(int points, string name, string description, int timesCompleted) : base (points, name, description) {
        _timesCompleted = timesCompleted;
    }

}