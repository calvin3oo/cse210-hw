using System;

class Program
{
    static void Main(string[] args)
    {
        //create a job object
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2010;
        job1._endYear = 2012;

        //display the job object
        //job1.Display();

        //create another job
        Job job2 = new Job();
        job2._company = "Google";
        job2._jobTitle = "Software Engineer";
        job2._startYear = 2012;
        job2._endYear = 2014;

        //display the job object
        //job2.Display();

        //create a resume object
        Resume resume = new Resume();
        resume._name = "John Smith";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        //display the resume object
        resume.Display();

    }
}