
using System;

public class Job
{
    // Member variables (fields)
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    // Behavior: Display job information as "Job Title (Company) StartYear-EndYear"
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}
