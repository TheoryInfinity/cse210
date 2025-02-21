public class Assignment {
    protected string _studentName;
    protected string _topic;

    public Assignment() {
        _studentName = "Unknown";
        _topic = "Undefined";
    }

    public Assignment(string name, string topic) {
        _studentName = name;
        _topic = topic;
    }

    public void GetSummary() {
        Console.WriteLine($"{_studentName}    {_topic}");
    }
}