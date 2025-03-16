using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> _goals = new List<Goal>();

        bool done = false;

        int points = 0;

        string fileName = "Goals.txt";

        while (!done)
        {

            Console.WriteLine($"\nYou have {points} points.\n");

            Console.WriteLine("Menu Options:");
            Console.WriteLine("   1. Create New Goal");
            Console.WriteLine("   2. List Goals");
            Console.WriteLine("   3. Save Goals");
            Console.WriteLine("   4. Load Goals");
            Console.WriteLine("   5. Record Event");
            Console.WriteLine("   6. Quit");
            Console.Write("Select an option:");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nSelect a type of goal:");
                    Console.WriteLine("   1: Simple Goal");
                    Console.WriteLine("   2: Eternal Goal");
                    Console.WriteLine("   3: Checklist Goal");
                    Console.WriteLine("   4: Nevermind. I have no goals to add.");
                    Console.WriteLine("Which type would you like to create?");

                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("\nName your simple goal:");
                            string name = Console.ReadLine();
                            Console.Write("\nType points rewarded for this goal:");
                            int goalPoints = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\nDescibe this goal:");
                            string desciption = Console.ReadLine();
                            SimpleGoal newSimple = new SimpleGoal(goalPoints, name, desciption);
                            _goals.Add(newSimple);
                            break;
                        case "2":
                            Console.Write("\nName your eternal goal:");
                            name = Console.ReadLine();
                            Console.Write("\nType points rewarded for this goal:");
                            goalPoints = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\nDescibe this goal:");
                            desciption = Console.ReadLine();
                            EternalGoal newEternal = new EternalGoal(goalPoints, name, desciption);
                            _goals.Add(newEternal);
                            break;
                        case "3":
                            Console.Write("\nName your checklist goal:");
                            name = Console.ReadLine();
                            Console.Write("\nType points rewarded each completion:");
                            goalPoints = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\nType number of times until finished:");
                            int times = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\nType bonus points rewarded for final completion");
                            int bonusPoints = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\nDescibe this goal:");
                            desciption = Console.ReadLine();
                            ChecklistGoal newChecklist = new ChecklistGoal(goalPoints, name, desciption, bonusPoints, times);
                            _goals.Add(newChecklist);
                            break;
                        case "4":
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }

                    break;
                case "2":
                    foreach (Goal goal in _goals)
                    {
                        goal.Display();
                        Console.WriteLine("");
                    }
                    break;
                case "3":
                    using (StreamWriter outputFile = new StreamWriter(fileName))
                    {
                        string pointsString = $"Points:|:{points}";
                        foreach (Goal goal in _goals)
                        {
                            string goalString = goal.GetRep();
                            outputFile.WriteLine(goalString);
                        }
                    }
                    Console.Clear();
                    break;
                case "4":
                    string[] lines = System.IO.File.ReadAllLines(fileName);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(":|:");
                        string goalType = parts[0];
                        if (goalType == "Points")
                        {
                            points = Convert.ToInt32(parts[1]);
                        }
                        else if (goalType == "SimpleGoal")
                        {
                            SimpleGoal newSimple = new SimpleGoal(Convert.ToInt32(parts[1]), parts[2], parts[3], Convert.ToBoolean(parts[4]));
                            _goals.Add(newSimple);
                        }
                        else if (goalType == "EternalGoal")
                        {
                            EternalGoal newEternal = new EternalGoal(Convert.ToInt32(parts[1]), parts[2], parts[3], Convert.ToInt32(parts[4]));
                            _goals.Add(newEternal);
                        }
                        else if (goalType == "ChecklistGoal")
                        {
                            ChecklistGoal newChecklist = new ChecklistGoal(Convert.ToInt32(parts[1]), parts[2], parts[3], Convert.ToInt32(parts[4]), Convert.ToInt32(parts[5]), Convert.ToInt32(parts[6]));
                            _goals.Add(newChecklist);
                        }
                    }
                    Console.Clear();
                    break;
                case "5":
                    string completedgoalname = Console.ReadLine();
                    bool goalFound = false;
                    foreach (Goal goal in _goals)
                    {
                        if (completedgoalname == goal.GetName())
                        {
                            points += goal.IsCompleted();
                            goalFound = true;
                        }
                    }
                    if (goalFound == false)
                    {
                        Console.WriteLine("Goal Not found");
                    }
                    Console.Clear();
                    break;
                case "6":
                    done = true;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }

        }
    }
}