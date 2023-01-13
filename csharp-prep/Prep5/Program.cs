using System;

class Program
{
    static void Main(string[] args)
    {
        //welcome the user
        DisplayWelcome();

        //ask the user to enter their name
        string name = PromptUserName();

        //ask the user to enter their favorite number
        int favoriteNumber = PromptUserNumber();

        //print the name and favorite number
        DisplayResult(name, SquareNumber(favoriteNumber));
    }

    //create a welcome user function that prints out 'welcome to the program'
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    //create a PromptUserName that asks for the user's name and returns it
    static string PromptUserName()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    //create a PromptUserNumber that asks for the user's favorite number and returns it
    static int PromptUserNumber()
    {
        Console.Write("Enter your favorite number: ");
        string favoriteNumber = Console.ReadLine();
        int favoriteNumberInt = int.Parse(favoriteNumber);
        return favoriteNumberInt;
    }

    //create a square number function that takes in an int and returns the square of that number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    //create a DisplayResult function that accepts the name, and the squared number, and displays them
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}.");
    }

}