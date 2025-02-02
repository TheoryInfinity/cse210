using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        Journal _journal = new Journal();

        while (true) {

            menu.Display();
            string choice = Console.ReadLine();

            if (choice == "1") {
                 Console.WriteLine("");
                _journal.Write();
            }
            else if (choice == "2") {
                 Console.WriteLine("");
                _journal.Display();
            }
            //added error catching to help not crash if you try to load a non-existant journal.
            else if (choice == "3") {
                 Console.WriteLine("");
                _journal.Load();
            }
            else if (choice == "4") {
                 Console.WriteLine("");
                _journal.Save();
            }
            //added option to delete an unwanted entry.
            //error handling to manage deleting from an empty list or deleting a non-existant entry.
            else if (choice == "5") {
                 Console.WriteLine("");
                _journal.Delete();
            }
            else if (choice == "6") {
                 Console.WriteLine("");
                if (_journal._changed) {
                    Console.WriteLine("You have unsaved changes which will be lost. Are you sure you want to quit? (y/n)");
                    string quitResponse = Console.ReadLine()?.ToLower() ?? "";
                    if (quitResponse == "y" || quitResponse == "yes") {
                        break;
                    }
                    continue;
                }
                break;
            }
            else {
                Console.WriteLine("");
                Console.WriteLine("Please enter a valid Input.");
            }
        }   

    }
}
