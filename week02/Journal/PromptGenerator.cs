
using System;
using System.Collections.Generic;

namespace JournalApp
{
    /// <summary>
    /// Supplies random prompts to reduce writer's block.
    /// </summary>
    public class PromptGenerator
    {
        private readonly List<string> _prompts = new()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            // You can add your own to personalize:
            "What is something small I’m grateful for right now?",
            "What did I learn today that surprised me?"
        };

        private readonly Random _rand = new();

        public string GetRandomPrompt()
        {
            int idx = _rand.Next(_prompts.Count);
            return _prompts[idx];
        }

        public void AddPrompt(string prompt)
        {
            if (!string.IsNullOrWhiteSpace(prompt))
            {
                _prompts.Add(prompt.Trim());
            }
        }   
    }
}
