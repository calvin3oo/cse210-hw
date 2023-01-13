using System;

class Program
{
    static void Main(string[] args)
    {
        //generate a random integer between 1 and 100
        Random rand = new Random();
        int number = rand.Next(1, 101);

        while (true){
            //ask the user what is your guess?
            Console.Write("What is your guess? ");
            string guess = Console.ReadLine();

            //convert the guess to an int
            int guessInt = int.Parse(guess);

            //check if the guess is correct
            if (guessInt == number)
            {
                Console.WriteLine("You guessed correctly!");
                break;
            }
            else if (guessInt > number)
            {
                Console.WriteLine("You guessed too high!");
            }
            else if (guessInt < number)
            {
                Console.WriteLine("You guessed too low!");
            }
        }
    }
}