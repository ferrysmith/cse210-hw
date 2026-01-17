

// using System;

// class Program
// {
//     static void Main()
//     {
//         // Ask the user for their grade percentage
//         Console.Write("What is your grade percentage? ");
//         string input = Console.ReadLine();

//         // Convert input to an integer safely
//         bool isNumber = int.TryParse(input, out int percent);

//         if (!isNumber)
//         {
//             Console.WriteLine("That wasn't a valid number. Please run the program again and enter a whole number.");
//             return;
//         }

//         // Core: Determine the letter grade
//         string letter;

//         if (percent >= 90)
//         {
//             letter = "A";
//         }
//         else if (percent >= 80)
//         {
//             letter = "B";
//         }
//         else if (percent >= 70)
//         {
//             letter = "C";
//         }
//         else if (percent >= 60)
//         {
//             letter = "D";
//         }
//         else
//         {
//             letter = "F";
//         }

//         // Stretch: Determine the sign (+ or - or none)
//         // Rule:
//         //   "+" if last digit >= 7
//         //   "-" if last digit < 3
//         //   none otherwise
//         //
//         // Exception:
//         //   No A+ (only A or A-)
//         //   No F+ or F- (only F)
//         string sign = ""; // Start with no sign

//         // To find the "last digit", use the remainder operator (%).
//         // Example: 87 % 10 == 7, 92 % 10 == 2
//         int lastDigit = percent % 10;

//         if (letter == "F")
//         {
//             // F never has + or -
//             sign = "";
//         }
//         else if (letter == "A")
//         {
//             // A+ does not exist. Only A or A-.
//             if (lastDigit < 3)
//             {
//                 sign = "-";
//             }
//             else
//             {
//                 sign = ""; // no A+
//             }
//         }
//         else
//         {
//             // For B, C, D: apply normal + / - rules
//             if (lastDigit >= 7)
//             {
//                 sign = "+";
//             }
//             else if (lastDigit < 3)
//             {
//                 sign = "-";
//             }
//             else
//             {
//                 sign = ""; // no sign
//             }
//         }

//         // Print the final grade once (letter + sign)
//         Console.WriteLine($"Your letter grade is: {letter}{sign}");

//         // Pass/Fail message (need at least 70 to pass)
//         if (percent >= 70)
//         {
//             Console.WriteLine("Congratulations! You passed the course.");
//         }
//         else
//         {
//             Console.WriteLine("Keep going—you’ll do better next time!");
//         }
//     }
// }



using System;
using System.Diagnostics;
using System.Transactions;

string letter ="";
Console.Write("What is your grade percentage? ");
string input = Console.ReadLine();
bool grade = int.TryParse(input, out int percent);
if (percent >=90)
{
    letter = "A";

}

else if (percent >=80)
{
    letter = "B";
}
else if (percent >=70)
{
    letter = "C";
}
else if (percent >=60)
{
    letter = "D";
}
else if (percent >=50)
{
    letter = "E";
}
else if (percent <=40)
letter = "F";

// determine last digit to be negative or positive.
string sign = "";
int lastDigit = percent % 10;
if (lastDigit >7)
{
    sign = "+";
}
else if (lastDigit <3)
{
    sign = "-";
}
if (letter == "F")
{
    sign = "";
}
else if (letter =="A")
{
    if (lastDigit <3)
    {
        sign = "-";
    }
    else if (lastDigit >7)
    {
        sign = "";
    }
}
Console.Write($"your grade is {letter}{sign} ");
Console.ReadLine();



