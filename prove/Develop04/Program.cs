using System;

class Program
{
    static void Main(string[] args)
    {
        bool finished = false;

        while(!finished){
            int activityNum = promptAndGetActivityNum();

            switch(activityNum){
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Play();
                    break;
                case 2:
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Play();
                    break;
                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Play();
                    break;
                case 4:
                    Console.WriteLine("Goodbye");
                    finished = true;
                    break;
            }
        }
    }

    static Boolean isValidResponse(string response){
        if(response == "1" || response == "2" || response == "3" || response == "4"){
            return true;
        } else {
            return false;
        }
    }

    /**
    * Prompts the user with the menu, and asks for an activity number.
    * @return The activity number.
    */
    static int promptAndGetActivityNum(){

        // Prompt the user for a number.
        Console.WriteLine("Menu Options:");
        Console.WriteLine("\t1. Start breathing activity");
        Console.WriteLine("\t2. Start reflecting activity");
        Console.WriteLine("\t3. Start listing activity");
        Console.WriteLine("\t4. Quit");
        Console.Write("Select a choice from the menu: ");

        // Get the user's response, and verify it's valid.
        string response = Console.ReadLine();

        while(!isValidResponse(response)){
            Console.Write("Please enter a valid number between 1 and 4: ");
            response = Console.ReadLine();
        }

        // Return the activity number.
        return Int32.Parse(response);
    }
}