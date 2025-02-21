public class MathAssignment : Assignment {
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string name, string topic, string section, string problems) {
        _studentName = name;
        _topic = topic;
        _textbookSection = section;
        _problems = problems;
    }

    public void DisplayHomeworkList() {
        Console.WriteLine($"{_textbookSection}   {_problems}");
    }
}