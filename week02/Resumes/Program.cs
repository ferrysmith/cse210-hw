
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");

        // Create first job
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        // Create second job
        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        // Verify we can display company names (initial test)
        Console.WriteLine(job1._company);
        Console.WriteLine(job2._company);

        // Now, replace the direct company prints with the Display() method:
        job1.Display();
        job2.Display();
    }
}
