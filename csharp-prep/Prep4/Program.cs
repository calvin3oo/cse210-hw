using System;

class Program
{
    static void Main(string[] args)
    {
        //create a list to hold integers
        List<int> numbers = new List<int>();

        //ask the user for a set of numbers, and tell them to enter 0 when they are done
        Console.WriteLine("Enter a set of numbers, and enter 0 when you are done.");
        while (true){
            //ask the user for a number
            Console.Write("Enter a number: ");
            string number = Console.ReadLine();

            //convert the number to an int
            int numberInt = int.Parse(number);

            //check if the number is 0
            if (numberInt == 0)
            {
                break;
            }
            else
            {
                //add the number to the list
                numbers.Add(numberInt);
            }
        }

        //print out the sum of the numbers in the list
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum of the numbers is {sum}.");
        
        //print out the average of the numbers in the list
        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The average of the numbers is {average}.");

        //print out the largest number in the list
        int largest = numbers[0];
        foreach (int number in numbers)
        {
            if (number > largest)
            {
                largest = number;
            }
        }
        Console.WriteLine($"The largest number is {largest}.");
        
    }
}