
using System;

{
    {
        static void Main(string[] args)
        {
            // 1) Show welcome
            DisplayWelcome();

            // 2) Ask for user's name (string)
            string userName = PromptUserName();

            // 3) Ask for user's favorite number (int)
            int favoriteNumber = PromptUserNumber();

            // 4) Square the number
            int squared = SquareNumber(favoriteNumber);

            // 5) Display the result
            DisplayResult(userName, squared);
        }

        /// <summary>
        /// Displays the welcome message.
        /// </summary>
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        /// <summary>
        /// Prompts for and returns the user's name.
        /// </summary>
        /// <returns>Entered name as a string.</returns>
        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name ?? string.Empty;
        }

        /// <summary>
        /// Prompts for and returns the user's favorite number as an integer.
        /// Includes a simple validation loop to ensure an integer is entered.
        /// </summary>
        /// <returns>Favorite number as an int.</returns>
        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            while (true)
            {
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                {
                    return number;
                }

                Console.Write("That wasn't a valid integer. Please enter your favorite number: ");
            }
        }

        /// <summary>
        /// Returns the square of the given integer.
        /// </summary>
        /// <param name="number">The number to square.</param>
        /// <returns>Squared value as an int.</returns>
        static int SquareNumber(int number)
        {
            return number * number;
        }

        /// <summary>
        /// Displays the user's name and the squared number.
        /// </summary>
        /// <param name="name">User's name.</param>
        /// <param name="squaredNumber">Squared number.</param>
        static void DisplayResult(string name, int squaredNumber)
        {
            Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
        }
    }
}
