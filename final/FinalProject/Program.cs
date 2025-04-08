using System;
using System.Collections;
using System.Diagnostics.Contracts;

class Program
{
    static void Main(string[] args)
    {

        List<User> users = new List<User>();
        List<Storage> units = new List<Storage>();
        List<Contract> allContracts = new List<Contract>();
        Dictionary<int, int> unitBaseCosts = new Dictionary<int, int>();

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
                    Console.WriteLine("\nAvailable Units:");
                    bool anyAvailable = false;

                    foreach (Storage unit in units)
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
                            Console.WriteLine(unit.ToDisplayString());
                            anyAvailable = true;
                        }
                    }

                    if (!anyAvailable)
                    {
                        Console.WriteLine("No units currently available.");
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
                        Console.WriteLine("You have no contracts");
                        break;
                    case "3":
                        SignContract(currentUser, units, allContracts, unitBaseCosts);
                        break;
                    case "4":
                        Console.WriteLine("You have no contracts");
                        break;
                    case "5":
                        Console.WriteLine("Account information not available at this time");
                        break;
                    case "6":
                        intro = true;
                        loggedin = false;
                        break;
                    case "7":
                        loggedin = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
        // Will initialize with a list of all available storage boxes\
        // Will have a login menu
        // Will save and load users from a database.
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
}