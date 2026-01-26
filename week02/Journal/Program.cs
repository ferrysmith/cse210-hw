
using System;
using JournalApp;

/*
CSE 210 - W02 Journal Program

Core requirements implemented:
- Write new entry (random prompt, capture response, store with date)
- Display all entries
- Save to file (custom delimiter "~|~")
- Load from file (replaces current list)
- Menu-based console app
- ≥5 prompts
- Abstraction via classes: Entry, Journal, PromptGenerator (+ Program)

Exceeds requirements (documenting here per assignment):
- Optional "Mood" field saved with each entry.
- Save/Load as CSV (proper escaping for commas/quotes/newlines).
- Save/Load as JSON.

If you used this as a reference, please adapt it to your own style and
mention in your submission comments that you used AI assistance.
*/

namespace JournalApp;

class Program

{
    static void Main()
    {
        var journal = new Journal();
        var prompts = new PromptGenerator();

        bool running = true;
        while (running)
        {
            PrintMenu();
            Console.Write("Select an option (1-9): ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, prompts);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save (e.g., journal.txt): ");
                    var savePath = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(savePath))
                        journal.SaveToFile(savePath.Trim());
                    break;

                case "4":
                    Console.Write("Enter filename to load (e.g., journal.txt): ");
                    var loadPath = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(loadPath))
                        journal.LoadFromFile(loadPath.Trim());
                    break;

                case "5":
                    Console.Write("CSV filename to save (e.g., journal.csv): ");
                    var csvSave = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(csvSave))
                        journal.SaveToCsv(csvSave.Trim());
                    break;

                case "6":
                    Console.Write("CSV filename to load (e.g., journal.csv): ");
                    var csvLoad = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(csvLoad))
                        journal.LoadFromCsv(csvLoad.Trim());
                    break;

                case "7":
                    Console.Write("JSON filename to save (e.g., journal.json): ");
                    var jsonSave = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(jsonSave))
                        journal.SaveToJson(jsonSave.Trim());
                    break;

                case "8":
                    Console.Write("JSON filename to load (e.g., journal.json): ");
                    var jsonLoad = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(jsonLoad))
                        journal.LoadFromJson(jsonLoad.Trim());
                    break;

                case "9":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine("Journal Menu");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a (text) file");
        Console.WriteLine("4. Load the journal from a (text) file");
        Console.WriteLine("---- Exceeds (optional) ----");
        Console.WriteLine("5. Save as CSV");
        Console.WriteLine("6. Load from CSV");
        Console.WriteLine("7. Save as JSON");
        Console.WriteLine("8. Load from JSON");
        Console.WriteLine("9. Quit");
        Console.WriteLine();
    }

    static void WriteNewEntry(Journal journal, PromptGenerator prompts)
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd"); // OK to store as string (simplification)
        string prompt = prompts.GetRandomPrompt();

        Console.WriteLine();
        Console.WriteLine($"Date: {date}");
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Write your response below. Press Enter on a blank line to finish:");
        Console.WriteLine("---------------------------------------------------------------");

        // Support multi-line responses until a blank line
        var responseBuilder = new System.Text.StringBuilder();
        while (true)
        {
            string? line = Console.ReadLine();
            if (line == null || line.Length == 0) break;
            responseBuilder.AppendLine(line);
        }
        string response = responseBuilder.ToString().TrimEnd();

        Console.Write("Mood (optional, e.g., Happy/Grateful). Press Enter to skip: ");
        string? mood = Console.ReadLine();
        mood = string.IsNullOrWhiteSpace(mood) ? null : mood.Trim();

        journal.AddEntry(new Entry(date, prompt, response, mood));
        Console.WriteLine("\nEntry added!");
    }
}
