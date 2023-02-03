public class GoalUtilities{
    public static Goal createGoal(){
        // Display the types of Goals
        Console.WriteLine("Here are the types of goals you can create:");
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");
        Console.Write("What type of goal would you like to create? ");

        // Get the user's choice
        string input = Console.ReadLine();

        // Make sure the user's choice is valid
        while(!validGoalChoice(input)){
            Console.WriteLine("Invalid choice. Please enter a valid choice (1-3).");
            input = Console.ReadLine();
        }

        //Simple - Name, Description, Completion Points
        //Eternal - Name, Description, Completion Points
        //Checklist - Name, Description, points per milestone, number of milestones, Completion Points

        // Get the name
        Console.Write("What is the name of the goal? ");
        string name = Console.ReadLine();

        // Get the description
        Console.Write("What is a short description of the goal? ");
        string description = Console.ReadLine();

        // Get the completion points
        Console.Write("How many points will completing the goal be worth? ");
        string completionPoints = Console.ReadLine();

        // Convert the completion points to an integer
        int completionPointsInt = validateAndConvertToInt(completionPoints);

        switch(input){
            case "1":
                // Simple Goal
                return new SimpleGoal(name, description, completionPointsInt);
            case "2":
                // Eternal Goal
                return new EternalGoal(name, description, completionPointsInt);
            case "3":
                // Checklist Goal
                
                // Get the number of milestones for this goal
                Console.Write("How many milestones are there? ");
                string numMilestones = Console.ReadLine();

                // Validate that the number of milestones is an integer
                int numMilestonesInt = validateAndConvertToInt(numMilestones);

                // Get the points per milestone
                Console.Write("How many points are each milestone worth? ");
                string pointsPerMilestone = Console.ReadLine();

                // Validate that the points per milestone is an integer
                int pointsPerMilestoneInt = validateAndConvertToInt(pointsPerMilestone);

                return new ChecklistGoal(name, description, completionPointsInt, numMilestonesInt, pointsPerMilestoneInt);
        }

        throw new Exception("Invalid goal choice: " + input);
    }

    public static string listGoals(List<Goal> goals){
        string output = "Here are your goals:\n";

        // Loop through the goals and add them to the output
        for(int i = 0; i < goals.Count; i++){
            output += (i + 1) + ". " + goals[i].ToString() + "\n";
        }

        return output;
    }

    public static void saveGoals(List<Goal> goals){
        // Create a new file
        StreamWriter file = new StreamWriter("goals.txt");

        // Loop through the goals and write them to the file
        for(int i = 0; i < goals.Count; i++){
            file.WriteLine(goals[i].ToString());
        }

        // Close the file
        file.Close();
    }

    public static string genericGoalDesc(string name, string description, Boolean completed){
        string addToBeginning = "[ ] ";
        if(completed) addToBeginning = "[X] ";

        return addToBeginning + name + " (" + description + ")";
    }

    public static Boolean validGoalChoice(string input){
        // Check if the user's choice is valid
        if(input == "1" || input == "2" || input == "3"){
            return true;
        } else {
            return false;
        }
    }

    public static int validateAndConvertToInt(string input){
        int output;
        // Validate that the completion points is an integer
        while(int.TryParse(input, out output) == false){
            Console.WriteLine("Please enter a valid integer.");
            input = Console.ReadLine();
        }

        return output;
    }
}