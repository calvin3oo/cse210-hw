using System;

public class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    // public Job(string company, string jobTitle, int startYear, int endYear)
    // {
    //     _company = company;
    //     _jobTitle = jobTitle;
    //     _startYear = startYear;
    //     _endYear = endYear;
    // }
    public void Display()
    {
        Console.WriteLine("{0} ({1}) {2}-{3}", _jobTitle, _company, _startYear, _endYear);
    }
}