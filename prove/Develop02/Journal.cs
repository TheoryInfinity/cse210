using System;
using System.Collections.Generic;
using System.IO;

public class Journal {
    public List<Entry> _contents = new List<Entry>();
    PromptManager _promptManager = new PromptManager();

    public bool _changed = false;

    public void Write() {
        Entry newEntry = new Entry();
        _contents.Add(newEntry);
        _changed = true;

        newEntry._date = GetDate();
        newEntry._prompt = _promptManager.GetPrompt();
        Console.WriteLine(newEntry._prompt);
        newEntry._response = Console.ReadLine();

    }


    public string GetDate() {
        return DateTime.Now.ToString("yyyy-MM-dd");
    }

    public void Display() {
        for (int i = 0; i < _contents.Count; i++) {
            Console.WriteLine($"======================");
            Console.WriteLine($"Entry #{i + 1}");
            Console.WriteLine($"Date: {_contents[i]._date}");
            Console.WriteLine($"Prompt: {_contents[i]._prompt}");
            Console.WriteLine($"Response: {_contents[i]._response}");
        };
        Console.WriteLine($"======================");
    }

        // Added code to remove unwanted entries from a journal if desired.
    public void Delete() {
        try {
            if (_contents.Count == 0) {
                Console.WriteLine("No entries to delete.");
                return;
            }

            Console.WriteLine("Which entry would you like to delete? (1-" + _contents.Count + ")");
            string input = Console.ReadLine();
            
            if (!int.TryParse(input, out int index)) {
                Console.WriteLine("Please enter a valid number.");
                return;
            }
            index--;

            if (index < 0 || index >= _contents.Count) {
                Console.WriteLine($"Please enter a number between 1 and {_contents.Count}");
                return;
            }

            _contents.RemoveAt(index);
            _changed = true;
            Console.WriteLine("Entry deleted successfully.");
        }
        catch (Exception ex) {
            Console.WriteLine($"Error deleting entry: {ex.Message}");
        }
    }

    public void Save() {
        string filename = "journal.txt";

        if (File.Exists(filename)) {
            Console.WriteLine("Warning: Saving will overwite your current journal. Continue? (y/n)");
            string response = Console.ReadLine()?.ToLower() ?? "";
            if (response != "y" && response != "yes") {
                Console.WriteLine("Save cancelled.");
                return;
            }
        }

        try {
            using (StreamWriter outputFile = new StreamWriter(filename)) {
                foreach (Entry entry in _contents) {
                    outputFile.WriteLine($"{entry._date}~|~{entry._prompt}~|~{entry._response}");
                }
                Console.WriteLine("Save successful.");
            }
            _changed = false;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void Load() {
        string filename = "journal.txt";

        try {
            if (_changed) {
                Console.WriteLine("Warning: You have unsaved changes. Loading a new journal will discard these changes. Continue? (y/n)");
                string response = Console.ReadLine()?.ToLower() ?? "";
                if (response != "y" && response != "yes") {
                    Console.WriteLine("Load cancelled.");
                    return;
                }
            }

            if (!File.Exists(filename)) {
                Console.WriteLine("No journal found.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            _contents.Clear();

            foreach (string line in lines) {
                string[] parts = line.Split("~|~");
                if (parts.Length == 3) {
                    Entry entry = new Entry();
                    entry._date = parts[0];
                    entry._prompt = parts[1];
                    entry._response = parts[2];
                    _contents.Add(entry);
                }
            }

            if (_contents.Count > 0) {
                Console.WriteLine($"The last time you wrote in this journal was {_contents[_contents.Count - 1]._date}");
            }

            _changed = false;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error loading Journal: {ex.Message}");
        }
    }

}
