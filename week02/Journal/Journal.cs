
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JournalApp
{
    /// <summary>
    /// Manages a collection of entries and handles display, save, and load.
    /// </summary>
    public class Journal
    {
        private readonly List<Entry> _entries = new();

        public void AddEntry(Entry entry) => _entries.Add(entry);

        public void Clear() => _entries.Clear();

        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("Your journal is empty.\n");
                return;
            }

            Console.WriteLine("---- Journal Entries ----\n");
            foreach (var e in _entries)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("-------------------------\n");
        }

        // ---------------- Core (simple delimiter file) ----------------
        public void SaveToFile(string path)
        {
            try
            {
                using var writer = new StreamWriter(path);
                foreach (var e in _entries)
                {
                    writer.WriteLine(e.ToStorageString());
                }
                Console.WriteLine($"Saved { _entries.Count } entries to \"{path}\".");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        public void LoadFromFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("File not found.");
                    return;
                }

                var lines = File.ReadAllLines(path);
                _entries.Clear();
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    _entries.Add(Entry.FromStorageString(line));
                }
                Console.WriteLine($"Loaded { _entries.Count } entries from \"{path}\".");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
        }

        // ---------------- Exceeds: CSV ----------------
        public void SaveToCsv(string path)
        {
            try
            {
                using var writer = new StreamWriter(path);
                writer.WriteLine("Date,Prompt,Response,Mood"); // header
                foreach (var e in _entries)
                {
                    writer.WriteLine(e.ToCsvRow());
                }
                Console.WriteLine($"Saved { _entries.Count } entries to CSV \"{path}\".");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving CSV: {ex.Message}");
            }
        }

        public void LoadFromCsv(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("CSV file not found.");
                    return;
                }

                using var reader = new StreamReader(path);
                _entries.Clear();

                bool isFirst = true;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) break;
                    if (isFirst)
                    {
                        isFirst = false;
                        // Skip header if present
                        if (line.Trim().StartsWith("Date,Prompt,Response")) continue;
                    }
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    _entries.Add(Entry.FromCsvRow(line));
                }
                Console.WriteLine($"Loaded { _entries.Count } entries from CSV \"{path}\".");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading CSV: {ex.Message}");
            }
        }

        // ---------------- Exceeds: JSON ----------------
        public void SaveToJson(string path)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(_entries, options);
                File.WriteAllText(path, json);
                Console.WriteLine($"Saved { _entries.Count } entries to JSON \"{path}\".");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving JSON: {ex.Message}");
            }
        }

        public void LoadFromJson(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("JSON file not found.");
                    return;
                }
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var json = File.ReadAllText(path);
                var entries = JsonSerializer.Deserialize<List<Entry>>(json, options);
                _entries.Clear();
                if (entries != null) _entries.AddRange(entries);
                Console.WriteLine($"Loaded { _entries.Count } entries from JSON \"{path}\".");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON: {ex.Message}");
            }
        }
    }
}
