using System;

class Program
{
    static void Main(string[] args)
    {
        // Write a program that asks the user for their first name and last name, and then prints out their full name in reverse order.
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        //ask for last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        //print out full name in reverse order
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");

    }
}