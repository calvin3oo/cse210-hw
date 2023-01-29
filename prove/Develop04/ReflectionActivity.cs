class ReflectionActivity : Activity{
    private static Random random = new Random();
    private static new string _name = "Reflection Activity";
    private static new string _description = "This activity will help you reflect on your day. It will ask you a series of questions, and you can answer them however you like.";
    private static string[] _beginningPrompts = {
        "What was the best part of your day?",
        "What was the worst part of your day?",
        "What did you learn today?",
        "What are you grateful for today?",
        "What are you looking forward to tomorrow?",
        "What are you proud of today?",
        "What are you worried about?",
        "What are you excited about?",
    };
    private static string[] _reflectionPrompts = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    private static int numberOfReflectionPrompts = 2;

    public ReflectionActivity() : base(_name, _description){
    }

    public void Play(){
        Intro();

        Console.WriteLine("Let's start with some questions about your day.");
        Console.WriteLine("Consider the following prompt: \n");

        // Randomly select a prompt from the beginningPrompts array.
        int promptIndex = random.Next(_beginningPrompts.Length);
        Console.WriteLine(_beginningPrompts[promptIndex]);
        Console.WriteLine();

        // Wait for the user to press enter to continue.
        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();

        Console.WriteLine("Now, let's reflect on your answer.");
        Console.Write("We start in: ");
        Countdown(3);

        Console.Clear();

        // Start the reflection prompts.
        float timeForEachPrompt = (float)_sessionLength / numberOfReflectionPrompts;

        for(int i=0; i<numberOfReflectionPrompts; i++){
            // Randomly select a prompt from the reflectionPrompts array.
            promptIndex = random.Next(_reflectionPrompts.Length);
            Console.Write(_reflectionPrompts[promptIndex]);
            SpinnerAnnimation(timeForEachPrompt);
        }

        Outro();
    }
}