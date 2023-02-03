public class Game{
    private Boolean _finished = false;
    private int _points = 0;
    private string _fileName;
    private List<Goal> _goals = new List<Goal>();

    public void Start(){

        // Game loop
        while(!_finished){
            // Print out how many points the user has
            Console.WriteLine();
            Console.WriteLine($"You have {0} points\n", _points);

            // Print the menu and get the user's choice
            printMenu();
            string input = Console.ReadLine();

            // Make sure the user's choice is valid
            while(!validMenuChoice(input)){
                Console.WriteLine("Invalid choice. Please enter a valid choice (1-6).");
                input = Console.ReadLine();
            }

            // Do the user's choice
            switch(input){
            case "1":
                // Create a new goal
                _goals.Add(GoalUtilities.createGoal());
                break;
            case "2":
                // List the goals
                Console.WriteLine(GoalUtilities.listGoals(_goals));
                break;
            case "3":
                // Save the goals
                GoalUtilities.saveGoals(_goals); // pickup here: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/use-dom-utf8jsonreader-utf8jsonwriter?pivots=dotnet-7-0
                break;
            case "4":
                // Load the goals
                Console.WriteLine("You chose to load the goals.");
                break;
            case "5":
                // Record an event
                Console.WriteLine("You chose to record an event.");
                break;
            case "6":
                // Quit the game
                Console.WriteLine("\nGoodbye!");
                _finished = true;
                break;
        }
        }
        
    }

    public Boolean validMenuChoice(string input){
        // Check if the user's choice is valid
        if(input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6"){
            return true;
        } else {
            return false;
        }
    }

    public void printMenu(){
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
    }
}