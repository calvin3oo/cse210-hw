using System.Diagnostics;
using System.Collections;

class ListingActivity : Activity{
    private Random random = new Random();
    private static new string _name = "Listening Activity";
    private static new string _description = "This activity will help you relax by listening to a calming sound. Clear your mind and focus on the sound.";
    private static string[] _prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private ArrayList _responses = new ArrayList();

    public ListingActivity() : base(_name, _description){}

    public void Play(){
        Intro();

        Console.WriteLine("List as many responses you can to the following prompt: ");
        // Randomly select a prompt from the prompts array.
        int promptIndex = random.Next(_prompts.Length);
        Console.WriteLine("---" + _prompts[promptIndex] + "---");
        Console.Write("You begin in: ");
        Countdown(5);

        // Start the timer.
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        // While the stopwatch is less than the session length, get input from the user.
        while(stopwatch.Elapsed.TotalSeconds < _sessionLength){
            Console.Write("> ");
            string response = Console.ReadLine();

            _responses.Add(response);
        }

        // Stop the timer.
        stopwatch.Stop();

        // Tell the user how many responses they submitted.
        Console.WriteLine("You submitted " + _responses.Count + " responses.");

        Outro();
    }
}