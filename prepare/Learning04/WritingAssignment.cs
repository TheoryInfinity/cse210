public class WritingAssignment : Assignment {
    private string _title;
    public WritingAssignment(string name, string topic, string title) {
        _studentName = name;
        _topic = topic;
        _title = title;
    }

    public void DisplayWritingInformation() {
        Console.WriteLine($"{_title}");
    }

}