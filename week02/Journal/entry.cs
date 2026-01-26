
using System;

namespace JournalApp
{
    /// <summary>
    /// Represents a single journal entry with date, prompt, response, and optional mood.
    /// </summary>
    public class Entry
    {
        public string Date { get; set; } = "";      // Stored as a string per assignment simplification
        public string Prompt { get; set; } = "";
        public string Response { get; set; } = "";
        public string? Mood { get; set; }           // Optional (extra credit)

        public Entry() { }

        public Entry(string date, string prompt, string response, string? mood = null)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
            Mood = mood;
        }

        public override string ToString()
        {
            var moodPart = string.IsNullOrWhiteSpace(Mood) ? "" : $" (Mood: {Mood})";
            return $"[{Date}]{moodPart}\nPrompt: {Prompt}\nResponse:\n{Response}\n";
        }

        // --------- Plain storage using a safe custom delimiter (core) ----------
        private const string Delimiter = "~|~";

        public string ToStorageString()
        {
            // We keep it simple: choose a delimiter unlikely to appear in normal text.
            return string.Join(Delimiter, new[] {
                Date ?? "", Prompt ?? "", Response ?? "", Mood ?? ""
            });
        }

        public static Entry FromStorageString(string line)
        {
            // Make loading resilient: handle older files with only 3 fields.
            var parts = line.Split(Delimiter, StringSplitOptions.None);
            string date = parts.Length > 0 ? parts[0] : "";
            string prompt = parts.Length > 1 ? parts[1] : "";
            string response = parts.Length > 2 ? parts[2] : "";
            string? mood = parts.Length > 3 ? parts[3] : null;

            return new Entry(date, prompt, response, mood);
        }

        // --------- CSV helpers (exceeds) ----------
        public string ToCsvRow()
        {
            return string.Join(",", EscapeCsv(Date), EscapeCsv(Prompt), EscapeCsv(Response), EscapeCsv(Mood ?? ""));
        }

        public static Entry FromCsvRow(string csvLine)
        {
            // Basic CSV parsing that handles quoted fields with commas and quotes
            var fields = CsvSplit(csvLine);
            string date = fields.Count > 0 ? fields[0] : "";
            string prompt = fields.Count > 1 ? fields[1] : "";
            string response = fields.Count > 2 ? fields[2] : "";
            string mood = fields.Count > 3 ? fields[3] : "";
            return new Entry(date, prompt, response, string.IsNullOrWhiteSpace(mood) ? null : mood);
        }

        private static string EscapeCsv(string input)
        {
            if (input == null) return "";
            bool mustQuote = input.Contains(',') || input.Contains('"') || input.Contains('\n') || input.Contains('\r');
            string s = input.Replace("\"", "\"\"");
            return mustQuote ? $"\"{s}\"" : s;
        }

        private static System.Collections.Generic.List<string> CsvSplit(string line)
        {
            var list = new System.Collections.Generic.List<string>();
            bool inQuotes = false;
            var current = new System.Text.StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (inQuotes)
                {
                    if (c == '"')
                    {
                        // Check for escaped quote
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            current.Append('"');
                            i++; // skip next
                        }
                        else
                        {
                            inQuotes = false;
                        }
                    }
                    else
                    {
                        current.Append(c);
                    }
                }
                else
                {
                    if (c == ',')
                    {
                        list.Add(current.ToString());
                        current.Clear();
                    }
                    else if (c == '"')
                    {
                        inQuotes = true;
                    }
                    else
                    {
                        current.Append(c);
                    }
                }
            }
            list.Add(current.ToString());
            return list;
        }
    }
}
