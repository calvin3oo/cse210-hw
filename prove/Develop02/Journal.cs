using System;


//create a Journal Class
class Journal {
    string FILE_PATH = "/Users/calvi/Code/Homework/cse210-hw/prove/Develop02/journalEntries/";

    private string fileName;
    private List<Entry> entries = new List<Entry>();

    //create a constructor
    public Journal(){}

    //create a method that adds an entry to the list
    public void addEntry(Entry entry){
        entries.Add(entry);
    }

    //get the file name of the journal
    public void setFileNameFromInput(){
        //prompt the user for a file name
        Console.WriteLine("Please enter the name of the file you would like to load");
        Console.Write("> ");
        this.fileName = Console.ReadLine();

        if(!this.fileName.Contains(".txt")){
            this.fileName = this.fileName + ".txt";
        }
    }

    //create a method that displays all entries
    public void viewAllEntries(){
        //loop through the list of entries
        foreach(Entry entry in entries){
            //display the entry
            Console.WriteLine(entry);
        }
    }

    //create a method that loads entries from an already-created file
    public void loadFile(){
        //clear all current entries
        this.entries.Clear();

        this.setFileNameFromInput();

        string[] lines;
        while (true){
            try{
                if(this.fileName == "0.txt"){
                    Console.WriteLine("exiting load file");
                    return;
                }
                lines = File.ReadAllLines(FILE_PATH+this.fileName);
                break;
            } catch (Exception e){
                Console.WriteLine("File not found, please enter a correct file name, or 0 to quit");
                this.setFileNameFromInput();
            }
        }

        //loop through the lines
        foreach(string line in lines){
            //create a new entry
            Entry entry = new Entry();

            //set the entry's text
            entry.fileStringToEntry(line);

            //add the entry to the list
            this.addEntry(entry);
        }
    }

    //create a method that saves entries to a file
    public void saveEntriesToFile(){
        //set the file name
        this.setFileNameFromInput();

        //create a string to store the new file's contents
        string newFileContents = "";

        //loop through the entries
        foreach(Entry entry in entries){
            //add the entry's text to the list
            newFileContents = newFileContents + entry.entryToFileString() + "\n";
        }

        while (true){
            try{
                if(this.fileName == "0.txt"){
                    Console.WriteLine("exiting save file");
                    return;
                }
                File.WriteAllText(FILE_PATH+this.fileName, newFileContents);
                break;
            } catch (Exception e){
                Console.WriteLine("File not found, please enter a correct file name, or 0 to quit");
                this.setFileNameFromInput();
            }
        }
        File.WriteAllText(FILE_PATH+this.fileName, newFileContents);
    }
}