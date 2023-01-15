using System;

/**
 * Name: Calvin Olson
 * Date: 2020-09-09
 * Assignment Name: Journal Program
 * Assignment Brief: create a journal program that allows the user to write entries and save them to a file
 * 
 * I created this program by following the instructions in the assignment brief,
 * I went above and beyond by using best practices for good error handling.
*/


class Program
{
    static void Main(string[] args)
    {
        //display 'welcome to the journal program'
        Console.WriteLine("Welcome to the journal program");

        //initialize my journal
        Journal journal = new Journal();

        //loop until the user wants to quit
        bool running = true;

        while(running){
            String input = getUserOptionSelection();

            switch(input){
                case "1": //Write a new entry
                    //create a new entry
                    Entry entry = new Entry();

                    //prompt the user to set the entry's text
                    entry.getInput();

                    //add the entry to the journal
                    journal.addEntry(entry);

                    break;
                case "2": //View all entries
                    journal.viewAllEntries();
                    break;
                case "3": //Load a file
                    journal.loadFile();
                    break;
                case "4": //Save an entry
                    journal.saveEntriesToFile();
                    break;
                case "5": //Quit
                    running = false;
                    break;
                default:
                    throw new Exception("Somehow this is an Invalid option");
            }
        }
        
        //tell the user goodbye
        Console.WriteLine("Goodbye");
    }

    static String getUserOptionSelection(){
        //ask the user to select an option
        Console.WriteLine("Please select an option");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. View all entries");
        Console.WriteLine("3. Load a file");
        Console.WriteLine("4. Save to a file");
        Console.WriteLine("5. Quit");

        //get the user's input
        while(true){
            try{
                String userOption = Console.ReadLine();
                if(userOption == "1" || userOption == "2" || userOption == "3" || userOption == "4" || userOption == "5"){
                    return userOption;
                }
                else{
                    Console.WriteLine("Please enter a valid option");
                }
            }
            catch(Exception e){
                Console.WriteLine("Please enter a valid option");
            }
        }

    }
}