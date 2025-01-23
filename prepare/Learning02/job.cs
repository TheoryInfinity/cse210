/*
Job
    Tracks:
        Company
        Job Title
        Start year
        End Year
    Does:
        Displays    "Job Title (Company) StartYear-EndYear".
*/

public class Job {
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;


    public void Display() {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}