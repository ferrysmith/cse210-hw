
// using System;
// using System.Diagnostics.CodeAnalysis;
// using System.Runtime.Versioning;

// // Features:
// // - Random number between 1 and 100.
// // - Prompts repeatedly until the correct guess.
// // - Tells the user "Higher" or "Lower".
// // - Counts guesses and displays the total.
// // - Asks to play again (type "yes" to continue).
// // - Handles invalid inputs safely with int.TryParse.
// // ---------------------------------------------------------

// Random random = new Random();   // One Random for the whole app
// bool keepPlaying = true;

// Console.WriteLine("Welcome to Guess My Number!");
// Console.WriteLine("I'll pick a number between 1 and 100. Try to guess it.");
// Console.WriteLine();

// while (keepPlaying)
// {
//     int secretNumber = random.Next(1, 101); // 1..100 inclusive
//     int guessCount = 0;
//     bool guessedCorrectly = false;

//     while (!guessedCorrectly)
//     {
//         Console.Write("Enter your guess (1 - 100): ");
//         string  input = Console.ReadLine();

//         // Validate numeric input
//         if (!int.TryParse(input, out int guess))
//         {
//             Console.WriteLine("Please enter a whole number (e.g., 42).");
//             continue;
//         }

//         // Optional range check for friendlier UX
//         if (guess < 1 || guess > 100)
//         {
//             Console.WriteLine("Your guess should be between 1 and 100.");
//             continue;
//         }

//         guessCount++;

//         if (guess < secretNumber)
//         {
//             Console.WriteLine("Higher");
//         }
//         else if (guess > secretNumber)
//         {
//             Console.WriteLine("Lower");
//         }
//         else
//         {
//             Console.WriteLine($"You guessed it! The number was {secretNumber}.");
//             Console.WriteLine($"Total guesses: {guessCount}");
//             guessedCorrectly = true;
//         }
//     }

//     Console.Write("Play again? Type 'yes' to continue, anything else to quit: ");
//     string answer = Console.ReadLine();
//     keepPlaying = answer != null &&
//                   answer.Trim().Equals("yes", StringComparison.OrdinalIgnoreCase);

//     Console.WriteLine(); // blank line between rounds
// }

// Console.WriteLine("Thanks for playing!");

using System;





bool guesscorrectly = false;
while (guesscorrectly)
    Console.Write("what is your guess?");
    string input = Console.ReadLine();
    bool number = int.tryparse(input, out int guess);
    if (number)
    {
        console.writeline("enter a whole number.");
    }
    if (guess < 1 || guess > 100)
    {
        console.writeline("guess must be between 1 and 100");
    }





