using System;

public class Resume
{
    public List<Job> _jobs = new List<Job>();
    public string _name;

    // public Job(string company, string jobTitle, int startYear, int endYear)
    // {
    //     _company = company;
    //     _jobTitle = jobTitle;
    //     _startYear = startYear;
    //     _endYear = endYear;
    // }
    public void Display()
    {
        Console.WriteLine("Name: {0}", _name);

        //create a for loop to loop through each job
        for (int i = 0; i < _jobs.Count; i++)
        {
            _jobs[i].Display();
        }
    }
}