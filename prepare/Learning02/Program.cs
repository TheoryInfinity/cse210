using System;

/*
Things
Job
    Tracks:
        Company
        Job Title
        Start year
        End Year
    Does:
        Displays    "Job Title (Company) StartYear-EndYear".
Resume
    Tracks:
        Name
        List of Jobs
    Does:
        Displays     "Name: 

*/
class Program
{
    static void Main(string[] args)
    {
        Job Carrot = new Job();
        Carrot._company = "Produce";
        Carrot._jobTitle = "Carrot";
        Carrot._startYear = 2005;
        Carrot._endYear= 2005;
        Carrot.Display();

        
        Job Soup = new Job();
        Soup._company = "Home";
        Soup._jobTitle = "Dinner";
        Soup._startYear = 2005;
        Soup._endYear= 2005;
        Soup.Display();

        Resume vitaminA = new Resume();
        vitaminA.name = "vitaminA";
        vitaminA.Jobs.Add(Carrot);
        vitaminA.Jobs.Add(Soup);

        vitaminA.Display();

    }
}