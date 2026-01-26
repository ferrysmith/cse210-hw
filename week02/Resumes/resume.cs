
using System;
using System.Collections.Generic;

public class Resume
{
    // Member variables
    public string _name;
    public List<Job> _jobs = new List<Job>(); // initialize list when declared

    // Behavior: Display resume details
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display(); // reuse Job's Display method
        }
    }
}
