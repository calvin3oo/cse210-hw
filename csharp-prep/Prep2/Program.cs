using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradePercentage = Console.ReadLine();

        //convert string to int
        int gradePercentageInt = int.Parse(gradePercentage);

        //create a char to hold the letter value
        char letterGrade;

        //check if grade is an A, B, C, D, or F
        if (gradePercentageInt >= 90)
        {
            letterGrade = 'A';
        }
        else if (gradePercentageInt >= 80)
        {
            letterGrade = 'B';
        }
        else if (gradePercentageInt >= 70)
        {
            letterGrade = 'C';
        }
        else if (gradePercentageInt >= 60)
        {
            letterGrade = 'D';
        }
        else
        {
            letterGrade = 'F';
        }

        //print out the letter grade
        Console.WriteLine($"Your letter grade is {letterGrade}.");

        // check if the grade is passing, and print out a congrats, or a try better next time
        if (gradePercentageInt >= 70)
        {
            Console.WriteLine("Congrats!");
        }
        else
        {
            Console.WriteLine("Try better next time!");
        }


    }
}