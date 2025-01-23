/*Resume
    Tracks:
        Name
        List of Jobs
    Does:
        Displays     "Name: 

*/

public class Resume {
    public string name;
    public List<Job> Jobs = new List<Job>();


    public void Display() {
        Console.WriteLine($"{name}:");
        foreach (Job a in Jobs) {
            a.Display();
        }
    }
}