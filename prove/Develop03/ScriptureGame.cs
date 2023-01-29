class ScriptureGame{
    private Boolean finished = false;
    public void run(){

        Scripture scripture = new Scripture(ScripturePicker.getRandomVerse());

        while(!finished){
            Console.Clear();

            // Print out the scripture.
            Console.WriteLine(scripture);
            Console.WriteLine(prompt());

            // Get the user input.
            string input = Console.ReadLine();
            if(input == "quit" || scripture.isEverythingInvisible()){
                finished = true;
                continue;
            }

            // Make some words dissapear.
            scripture.makeWordsDissapear();
        }
    }

    private string prompt(){
        return "\nPress enter to continue, or type 'quit' to quit";
    }
}