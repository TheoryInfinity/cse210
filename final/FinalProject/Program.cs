using System;

class Program
{
    static void Main(string[] args)
    {

        List<User> users = new List<User>();
        List<Storage> units = new List<Storage>();
        List<Contract> allContracts = new List<Contract>();
        Dictionary<int, int> unitBaseCosts = new Dictionary<int, int>();

        bool intro = true;
        bool login = false;

        while (intro) {
            
            Console.WriteLine("Menu Options:");
            Console.WriteLine("   1. List Available Units");
            Console.WriteLine("   2. Login");
            Console.WriteLine("   3. Quit");
            Console.Write("Select an option:");

            string choice = Console.ReadLine();
            
            switch (choice) {
                case "1":
                    Console.WriteLine("No Available Units");
                    break;
                case "2":
                    intro = false;
                    login = true;
                    // This will actually prompt for a login later. For now it gets us to the next menu.
                    break;
                case "3":
                    intro = false;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

            while (login) {
                
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
            
            switch (choice) {
                case "1":
                    Console.WriteLine("No Available Units");
                    break;
                case "2":
                    Console.WriteLine("You have no contracts");
                    break;
                case "3":
                    Console.WriteLine("No available contracts");
                    break;
                case "4":
                    Console.WriteLine("You have no contracts");
                    break;
                case "5":
                    Console.WriteLine("Account information not available at this time");
                    break;
                case "6":
                    intro = true;
                    login = false;
                    break;
                case "7":
                    login = false;
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
}