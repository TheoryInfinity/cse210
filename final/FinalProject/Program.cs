using System;
using System.Collections;
using System.Diagnostics.Contracts;
using System.IO.Enumeration;

class Program
{
    static void Main(string[] args)
    {

        List<User> users;
        List<Storage> units;
        List<Contract> allContracts;
        Dictionary<int, int> unitBaseCosts;

        LoadAll("Users.txt", "StorageUnits.txt", out users, out units, out unitBaseCosts, out allContracts);


        User currentUser = null;

        int nextUnitID = 1;

        // Standard Units
        var standardSmall = new StandardStorageUnit("small", nextUnitID);
        units.Add(standardSmall);
        unitBaseCosts[nextUnitID++] = standardSmall.GetBaseCost();

        var standardMedium = new StandardStorageUnit("medium", nextUnitID);
        units.Add(standardMedium);
        unitBaseCosts[nextUnitID++] = standardMedium.GetBaseCost();

        var standardLarge = new StandardStorageUnit("large", nextUnitID);
        units.Add(standardLarge);
        unitBaseCosts[nextUnitID++] = standardLarge.GetBaseCost();

        // Humidity-Controlled Units
        var humiditySmall = new HumidityControlledUnit("small", nextUnitID, 25);
        units.Add(humiditySmall);
        unitBaseCosts[nextUnitID++] = humiditySmall.GetBaseCost();

        var humidityMedium = new HumidityControlledUnit("medium", nextUnitID, 25);
        units.Add(humidityMedium);
        unitBaseCosts[nextUnitID++] = humidityMedium.GetBaseCost();

        var humidityLarge = new HumidityControlledUnit("large", nextUnitID, 25);
        units.Add(humidityLarge);
        unitBaseCosts[nextUnitID++] = humidityLarge.GetBaseCost();

        // Temperature-Controlled Units
        var tempSmall = new TemperatureControlledUnit("small", nextUnitID, 40);
        units.Add(tempSmall);
        unitBaseCosts[nextUnitID++] = tempSmall.GetBaseCost();

        var tempMedium = new TemperatureControlledUnit("medium", nextUnitID, 40);
        units.Add(tempMedium);
        unitBaseCosts[nextUnitID++] = tempMedium.GetBaseCost();

        var tempLarge = new TemperatureControlledUnit("large", nextUnitID, 40);
        units.Add(tempLarge);
        unitBaseCosts[nextUnitID++] = tempLarge.GetBaseCost();

        bool intro = true;
        bool loggedin = false;
        int activeUser = -1;

        while (intro)
        {

            Console.WriteLine("Menu Options:");
            Console.WriteLine("   1. List Available Units");
            Console.WriteLine("   2. Login");
            Console.WriteLine("   3. Create User");
            Console.WriteLine("   4. Quit");
            Console.Write("Select an option:");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    List<Storage> availableUnits = ListAvailableUnits(units, allContracts);

                    if (availableUnits.Count == 0)
                    {
                        Console.WriteLine("No units currently available.");
                    }
                    else
                    {
                        Console.WriteLine("\nAvailable Units:");
                        foreach (Storage unit in availableUnits)
                        {
                            Console.WriteLine(unit.ToDisplayString());
                        }
                    }

                    break;
                case "2":
                    Console.WriteLine("Please Enter your Username:");
                    string enteredName = Console.ReadLine();
                    Console.WriteLine("Please Enter your Password:");
                    string enteredPassword = Console.ReadLine();

                    bool loginSuccess = false;

                    foreach (User user in users)
                    {
                        if (enteredName == user.GetName() && enteredPassword == user.GetPassword())
                        {
                            activeUser = user.GetID();
                            currentUser = user;
                            loggedin = true;
                            loginSuccess = true;
                            intro = false;
                            Console.WriteLine("Login successful!");
                            break;
                        }
                    }

                    if (!loginSuccess)
                    {
                        Console.WriteLine("Login failed. Returning to main menu.");
                    }

                    break;
                case "3":
                    Console.Write("Enter new username: ");
                    string newName = Console.ReadLine();

                    bool nameTaken = false;
                    foreach (User user in users)
                    {
                        if (user.GetName() == newName)
                        {
                            nameTaken = true;
                            break;
                        }
                    }

                    if (nameTaken)
                    {
                        Console.WriteLine("That username is already taken.");
                        break;
                    }

                    Console.Write("Enter new password: ");
                    string newPassword = Console.ReadLine();

                    int newID = users.Count + 1;
                    User newUser = new User(newID, newName, newPassword);
                    users.Add(newUser);

                    Console.WriteLine("User created successfully!");
                    break;
                case "4":
                    intro = false;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

            while (loggedin)
            {

                Console.WriteLine("Menu Options:");
                Console.WriteLine("   1. List Available Units");
                Console.WriteLine("   2. Show Current Contracts");
                Console.WriteLine("   3. Sign a Contract");
                Console.WriteLine("   4. Cancel a Contract");
                Console.WriteLine("   5. Account Information");
                Console.WriteLine("   6. Logout");
                Console.WriteLine("   7. Quit");
                Console.Write("Select an option:");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        List<Storage> availableUnits = ListAvailableUnits(units, allContracts);

                        if (availableUnits.Count == 0)
                        {
                            Console.WriteLine("No units currently available.");
                        }
                        else
                        {
                            Console.WriteLine("\nAvailable Units:");
                            foreach (Storage unit in availableUnits)
                            {
                                Console.WriteLine(unit.ToDisplayString());
                            }
                        }
                        break;
                    case "2":
                        currentUser.ListActiveContracts(unitBaseCosts);
                        break;
                    case "3":
                        SignContract(currentUser, units, allContracts, unitBaseCosts);
                        SaveAll(units, users);
                        break;
                    case "4":
                        CancelUserContract(currentUser, unitBaseCosts);
                        SaveAll(units, users);
                        break;
                    case "5":
                        currentUser.Display(unitBaseCosts);
                        break;
                    case "6":
                        SaveAll(units, users);
                        intro = true;
                        currentUser = null;
                        loggedin = false;
                        break;
                    case "7":
                        SaveAll(units, users);
                        Console.WriteLine("Goodbye!");
                        loggedin = false;
                        intro = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
    }

    static void SignContract(User currentUser, List<Storage> units, List<Contract> allContracts, Dictionary<int, int> unitBaseCosts)
    {
        List<Storage> available = ListAvailableUnits(units, allContracts);

        foreach (Storage unit in available)
        {
            Console.WriteLine(unit.ToDisplayString());
        }

        int unitChoice;
        bool validChoice = false;

        do
        {
            Console.WriteLine("Enter the Unit ID (number) of the storage you want to rent:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out unitChoice))
            {
                foreach (Storage unit in available)
                {
                    if (unit.GetUnitID() == unitChoice)
                    {
                        validChoice = true;
                        break;
                    }
                }

                if (!validChoice)
                {
                    Console.WriteLine("That unit is not available. Please choose one from the list above.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric unit ID.");
            }

        } while (!validChoice);


        Console.WriteLine("How long would you like to rent this unit?");
        Console.WriteLine("1: 3  Months.");
        Console.WriteLine("2: 6  Months. 5% discount.");
        Console.WriteLine("3: 12 Months. 10% discount.");

        bool choiceSuccess = false;
        int duration = 0;
        double discount = 1.0;
        while (!choiceSuccess)
        {
            string durationChoice = Console.ReadLine();

            switch (durationChoice)
            {
                case "1":
                    duration = 3;
                    discount = 1.0;
                    choiceSuccess = true;
                    break;
                case "2":
                    duration = 6;
                    discount = 0.95;
                    choiceSuccess = true;
                    break;
                case "3":
                    duration = 12;
                    discount = 0.9;
                    choiceSuccess = true;
                    break;
                default:
                    Console.WriteLine("Please examine the options listed and make a valid choice.");
                    break;
            }
        }

        int baseCost = unitBaseCosts[unitChoice];
        double finalMonthlyCost = baseCost * discount;

        Console.WriteLine("These are the terms of your rental contract");
        Console.WriteLine($"Unit {unitChoice} | Duration: {duration} Months | Monthly Cost {finalMonthlyCost} | Total {finalMonthlyCost * duration}");
        Console.WriteLine("Do you wish to confirm this transaction?");

        string confirm = Console.ReadLine().Trim().ToLower();

        if (confirm != "y")
        {
            Console.WriteLine("Transaction cancelled. Returning to unit selection.");
            return;
        }

        Contract newContract = new Contract(currentUser.GetID(), unitChoice, duration, discount);
        currentUser.AddContract(newContract);
        allContracts.Add(newContract);
    }

    static void CancelUserContract(User currentUser, Dictionary<int, int> unitBaseCosts)
    {
        currentUser.ListActiveContracts(unitBaseCosts);

        Console.WriteLine("Enter the Unit ID of the contract you'd like to cancel:");
        string cancelInput = Console.ReadLine();
        int cancelID;

        if (int.TryParse(cancelInput, out cancelID))
        {
            Console.WriteLine("Are you sure you want to cancel this contract? You will have 5 days to undo this decision. (Y/N)");
            string confirmCancel = Console.ReadLine().Trim().ToLower();

            if (confirmCancel == "y")
            {
                bool success = currentUser.CancelContract(cancelID);
                if (success)
                {
                    Console.WriteLine($"Contract for Unit {cancelID} marked as canceled. You have 5 days to undo this action.");
                }
                else
                {
                    Console.WriteLine("No active contract found with that Unit ID.");
                }
            }
            else
            {
                Console.WriteLine("Cancellation aborted.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a numeric Unit ID.");
        }
    }

    static List<Storage> ListAvailableUnits(List<Storage> allUnits, List<Contract> allContracts)
    {
        List<Storage> availableStorage = new List<Storage>();

        foreach (Storage unit in allUnits)
        {
            bool available = true;

            foreach (Contract contract in allContracts)
            {
                if (contract.IsActive() && contract.GetUnitID() == unit.GetUnitID())
                {
                    available = false;
                    break;
                }
            }

            if (available)
            {
                availableStorage.Add(unit);
            }
        }

        return availableStorage;
    }

    static void SaveUnits(List<Storage> allunits)
    {
        string fileName = "StorageUnits.txt";
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Storage unit in allunits)
            {
                string unitString = unit.RepSaveString();
                outputFile.WriteLine(unitString);
            }
        }
    }

    static void SaveUsers(List<User> allusers)
    {
        string fileName = "Users.txt";
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (User user in allusers)
            {
                string userString = user.RepSaveString();
                outputFile.WriteLine(userString);
            }
        }
    }

    static void SaveAll(List<Storage> allunits, List<User> allusers)
    {
        SaveUnits(allunits);
        SaveUsers(allusers);
    }

    static List<Storage> LoadUnits(string filepath)
    {
        List<Storage> loaded = new List<Storage>();
        if (!File.Exists(filepath)) return loaded;

        string[] lines = File.ReadAllLines(filepath);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~");
            string StorageType = parts[0];

            if (StorageType == "Standard")
            {
                loaded.Add(new StandardStorageUnit(
                    int.Parse(parts[1]), parts[2], int.Parse(parts[3]), int.Parse(parts[4]),
                    int.Parse(parts[5]), int.Parse(parts[6])));
            }
            else if (StorageType == "Temperature-Controlled")
            {
                loaded.Add(new TemperatureControlledUnit(
                    int.Parse(parts[1]), parts[2], int.Parse(parts[3]), int.Parse(parts[4]),
                    int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]),
                    int.Parse(parts[8]), bool.Parse(parts[9])));
            }
            else if (StorageType == "Humidity-Controlled")
            {
                loaded.Add(new HumidityControlledUnit(
                    int.Parse(parts[1]), parts[2], int.Parse(parts[3]), int.Parse(parts[4]),
                    int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]),
                    int.Parse(parts[8]), bool.Parse(parts[9])));
            }
        }

        return loaded;
    }

    static List<User> LoadUsers(string filepath)
    {
        List<User> loadedUsers = new List<User>();
        if (!File.Exists(filepath)) return loadedUsers;

        string[] lines = File.ReadAllLines(filepath);
        foreach (string line in lines)
        {
            loadedUsers.Add(new User(line));
        }
        return loadedUsers;
    }

    static void LoadAll(string userPath, string unitPath, out List<User> users, out List<Storage> units, out Dictionary<int, int> unitBaseCosts, out List<Contract> allContracts)
    {
        users = LoadUsers(userPath);
        units = LoadUnits(unitPath);
        unitBaseCosts = new Dictionary<int, int>();

        foreach (Storage unit in units)
        {
            unitBaseCosts[unit.GetUnitID()] = unit.GetBaseCost();
        }

        allContracts = new List<Contract>();
        foreach (User user in users)
        {
            allContracts.AddRange(user.GetContracts());
        }
    }
}