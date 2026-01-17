using System;

class Program
{
 
    static void Main()
    {
        // 1) Ask the user for numbers until they type 0.
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // We'll store the numbers here.
        List<int> numbers = new List<int>();

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            // Try to convert the input to an integer.
            bool isNumber = int.TryParse(input, out int value);

            if (!isNumber)
            {
                // If the user typed something that's not a number, ask again.
                Console.WriteLine("Please enter a valid integer.");
                continue;
            }

            // If they type 0, stop. Do NOT add 0 to the list.
            if (value == 0)
            {
                break;
            }

            // Add the number to our list.
            numbers.Add(value);
        }

        // If the user didn't enter any numbers, let them know and exit.
        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers entered. Exiting program.");
            return;
        }

        // 2) Core Requirements

        // (a) Compute the sum
        int sum = 0;
        foreach (int n in numbers)
        {
            sum += n;
        }
        Console.WriteLine($"The sum is: {sum}");

        // (b) Compute the average
        // We cast sum to double to make sure we get decimal places, not integer division.
        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // (c) Find the largest number
        // Start with the first number, then compare each one.
        int largest = numbers[0];
        foreach (int n in numbers)
        {
            if (n > largest)
            {
                largest = n;
            }
        }
        Console.WriteLine($"The largest number is: {largest}");

        // 3) Stretch Challenge A: Smallest positive number (> 0)
        int? smallestPositive = null; // null means "not set yet"
        foreach (int n in numbers)
        {
            if (n > 0)
            {
                if (smallestPositive == null || n < smallestPositive.Value)
                {
                    smallestPositive = n;
                }
            }
        }

        if (smallestPositive != null)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive.Value}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers in the list.");
        }

        // 4) Stretch Challenge B: Sort and display the list
        numbers.Sort(); // Sorts the list from smallest to largest
        Console.WriteLine("The sorted list is:");
        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}


