


public class Entry {

    public string _date = "";
    public string _response = "";
    public string _prompt = "";

    public void Display() {
        Console.WriteLine($"{_date}");
        Console.WriteLine($"{_response}");
        Console.WriteLine($"{_prompt}");
    }  
}
