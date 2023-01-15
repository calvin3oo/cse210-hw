using System;

class Entry{
    string FILE_SEPERATOR = "~|[|]~";

    private String entryText;
    private String prompt;
    private String date;
    private Random rand = new Random();

    //build a constructor
    public Entry(){}

    //prompt a user for input
    public void getInput(){
        //list all the prompts
        string[] prompts = {
            "What was the most memorable moment of your day?",
            "What are three things you're grateful for today?",
            "What did you learn today?",
            "What was the best decision you made today?",
            "What was the most difficult part of your day?",
            "What was the most productive thing you did today?",
            "What was the most enjoyable thing you did today?",
            "What are your goals for tomorrow?"
        };

        //pick a random prompt
        this.prompt = prompts[rand.Next(0, prompts.Length)];

        //prompt the user for input
        Console.WriteLine(this.prompt);
        Console.Write("> ");

        //get the user's input
        this.entryText = Console.ReadLine();
        
        //store date the entry was added
        this.date = DateTime.Now.ToString("MM/dd/yyyy");
    }

    //create a method that converts a file string to an entry
    public void fileStringToEntry(string fileString){
        //split the string into an array
        string[] splitString = fileString.Split(FILE_SEPERATOR);

        //set the date
        this.date = splitString[0];

        //set the prompt
        this.prompt = splitString[1];

        //set the entry text
        this.entryText = splitString[2].Replace("\\n", "\n");
    }

    //create a method that converts an entry to a file string
    public string entryToFileString(){
        return string.Format("{0}{1}{2}{1}{3}", this.date, FILE_SEPERATOR, this.prompt, this.entryText).Replace("\n", "\\n");
    }

    //override the ToString method
    public override string ToString(){
        return string.Format("Date: {0} - Prompt: {1}\n {2}", this.date, this.prompt, this.entryText);
    }
}