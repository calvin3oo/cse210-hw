using System.Text.Json;
using System.Text.Json.Nodes;

public class GoalUtilities{
    public static JsonSerializerOptions JsonOptions = new JsonSerializerOptions { IncludeFields = true };
    public static string goalsDirectory = "goals";
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

    public static string getFileName(string action){
        // Get the file name from the user
        Console.Write("What is the name of the file to {0}? ", action);
        string fileName = Console.ReadLine();

        // Validate that the file name is correct
        while(!validFileName(fileName, ".json")){
            Console.WriteLine("Please enter a valid file name (no ., \\, /).");
            fileName = Console.ReadLine();
        }

        return "./"+ goalsDirectory +"/" + fileName + ".json";
    }

    public static void saveGoals(List<Goal> goals){
        string fileName = getFileName("save");

        // Create a JSON to write to the file
        List<string> goalsAsArray = new List<string>();
        for(int i = 0; i < goals.Count; i++){
            Type typeOfGoal = goals[i].GetType();

            switch(typeOfGoal){
                case Type t when t == typeof(SimpleGoal):
                    goalsAsArray.Add(JsonSerializer.Serialize<SimpleGoal>((SimpleGoal)goals[i], JsonOptions));
                    break;
                case Type t when t == typeof(EternalGoal):
                    goalsAsArray.Add(JsonSerializer.Serialize<EternalGoal>((EternalGoal)goals[i], JsonOptions));
                    break;
                case Type t when t == typeof(ChecklistGoal):
                    goalsAsArray.Add(JsonSerializer.Serialize<ChecklistGoal>((ChecklistGoal)goals[i], JsonOptions));
                    break;
                default:
                    throw new Exception("Invalid goal type: " + typeOfGoal);
            }
        }

        string json = "[" + string.Join(",", goalsAsArray) + "]";

        // Write the JSON to the file
        File.WriteAllText(fileName, json);

        // Close the file stream and release the file lock on the file so it can be opened again
        Console.WriteLine("Goals saved to {0}", fileName);

    }

    public static List<Goal> loadGoals(){
        List<Goal> goals = new List<Goal>();

        string fileName = getFileName("load");

        // Get the text in the file
        string jsonString = File.ReadAllText(fileName);

        // Read the JSON from the file
        JsonNode forecastNode = JsonNode.Parse(jsonString)!;

        JsonArray jsonNodeGoals = (JsonArray)forecastNode;

        // Loop through the goals and add them to the output
        for(int i = 0; i < jsonNodeGoals.Count; i++){
            string type = (string)jsonNodeGoals[i]["_type"];

            switch(type){
                case "Simple":
                    // Simple Goal
                    SimpleGoal simpleGoal = JsonSerializer.Deserialize<SimpleGoal>(jsonNodeGoals[i], JsonOptions);
                    goals.Add(simpleGoal);
                    break;
                case "Eternal":
                    // Eternal Goal
                    EternalGoal eternalGoal = JsonSerializer.Deserialize<EternalGoal>(jsonNodeGoals[i], JsonOptions);
                    goals.Add(eternalGoal);
                    break;
                case "Checklist":
                    // Checklist Goal
                    ChecklistGoal checklistGoal = JsonSerializer.Deserialize<ChecklistGoal>(jsonNodeGoals[i], JsonOptions);
                    goals.Add(checklistGoal);
                    break;
                default:
                    throw new Exception("Invalid goal type: " + type);
            }
        }

        return goals;
    }

    public static int recalculatePoints(List<Goal> _goals){
        int points = 0;

        // Loop through the goals and add their points to the total
        for(int i = 0; i < _goals.Count; i++){
            points += _goals[i].pointsEverEarned();
        }

        return points;
    }

    public static int getGoalNum(List<Goal> goals){
        // Display the goals
        Console.WriteLine(listGoals(goals));

        // Get the goal to record an event for
        Console.Write("Which goal would you like to record an event for? ");
        string goalChoice = Console.ReadLine();

        // Validate that the goal choice is an integer
        int goalChoiceInt = validateAndConvertToInt(goalChoice, 1, goals.Count);

        return goalChoiceInt;
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
    public static int validateAndConvertToInt(string input, int min, int max){
        int output;
        // Validate that the completion points is an integer
        while(int.TryParse(input, out output) == false || output < min || output > max){
            Console.WriteLine("Please enter a valid integer. {0} to {1}", min, max);
            input = Console.ReadLine();
        }

        return output;
    }

    public static Boolean validFileName(string fileName, string extension){
        // Check if the file name is valid
        if(fileName.Contains(".") || fileName.Contains("/") || fileName.Contains("\\")) return false;

        try{
            // Test if it's possible to create a file with the name
            File.Create(fileName + extension).Close();

            // Delete the file if it was created
            File.Delete(fileName + extension);
            return true;
        } catch(Exception e){
            Console.WriteLine(e);
            return false;
        }
    }
}