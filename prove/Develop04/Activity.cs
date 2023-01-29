class Activity
{
    protected string _name;
    protected string _description;
    protected int _sessionLength;
    
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Outro(){

        Console.WriteLine("Well Done!!");

        SpinnerAnnimation(3);
        Console.WriteLine();

        Console.WriteLine("Thank you for doing " + this._sessionLength + " seconds of the " + _name + " activity.\n");
        SpinnerAnnimation(3);

        Console.Clear();
    }

    public void Intro(){
        Console.Clear();

        Console.WriteLine("Welcome to the " + _name + " activity.\n");
        Console.WriteLine(_description + "\n");

        this._sessionLength = promptForSessionLength();

        Console.Clear();

        Console.WriteLine("Get Ready...");

        SpinnerAnnimation(3);

    }

    private int promptForSessionLength(){
        Console.Write("How long would you like to do this activity for? (in seconds): ");
        string response = Console.ReadLine();

        // Limit the seconds to be a number, not negative, and less than 600.
        while(!isValidSeconds(response) || Convert.ToInt32(response)<1 || Convert.ToInt32(response)>600){
            Console.Write("Please enter a valid number of seconds(positive, and up to 600): ");
            response = Console.ReadLine();
        }

        _sessionLength = Convert.ToInt32(response);
        return _sessionLength;
    }

    private Boolean isValidSeconds(string response){
        try{
            int seconds = Convert.ToInt32(response);
            return true;
        } catch (FormatException){
            return false;
        }
    }

    private string stringXLong(string character, int length){
        string result = "";
        for(int i=0; i<length; i++){
            result += character;
        }
        return result;
    }

    public void Countdown(int numOfSeconds){
        int numOfCharacters = numOfSeconds.ToString().Length;

        string spaces = stringXLong(" ", numOfCharacters);

        for(int i=numOfSeconds; i>0; i--){
            Console.Write(stringXLong(" ", numOfCharacters - i.ToString().Length) + i);
            System.Threading.Thread.Sleep(1000);
            Console.Write(stringXLong("\b", numOfCharacters));
        }
        Console.Write(spaces + "\n");
    }

    public void Countdown(float timeToWaste){
        int extraTimeToWaste = (int)((timeToWaste - (int)timeToWaste)*1000);
        System.Threading.Thread.Sleep(extraTimeToWaste);

        int numOfCharacters = ((int)timeToWaste).ToString().Length;

        string spaces = stringXLong(" ", numOfCharacters);

        for(int i = (int)timeToWaste; i>0; i--){
            Console.Write(stringXLong(" ", numOfCharacters - i.ToString().Length) + i);
            System.Threading.Thread.Sleep(1000);
            Console.Write(stringXLong("\b", numOfCharacters));
        }
        Console.Write(spaces + "\n");
    }

    public void SpinnerAnnimation(int numOfSeconds){
        int intervalBetweenMove = 100;
        int lengthOfSpin = intervalBetweenMove * 4;

        int numOfSpins = (numOfSeconds * 1000) / lengthOfSpin;

        for(int i=0; i<numOfSpins; i++){
            Console.Write("/");
            System.Threading.Thread.Sleep(intervalBetweenMove);
            Console.Write("\b");
            Console.Write("-");
            System.Threading.Thread.Sleep(intervalBetweenMove);
            Console.Write("\b");
            Console.Write("\\");
            System.Threading.Thread.Sleep(intervalBetweenMove);
            Console.Write("\b");
            Console.Write("|");
            System.Threading.Thread.Sleep(intervalBetweenMove);
            Console.Write("\b");
        }
        Console.Write(" \n");
    }
    public void SpinnerAnnimation(float numOfSeconds){
        int intervalBetweenMove = 100;
        int lengthOfSpin = intervalBetweenMove * 4;

        int numOfSpins = ((int)numOfSeconds * 1000) / lengthOfSpin;

        for(int i=0; i<numOfSpins; i++){
            Console.Write("/");
            System.Threading.Thread.Sleep(intervalBetweenMove);
            Console.Write("\b");
            Console.Write("-");
            System.Threading.Thread.Sleep(intervalBetweenMove);
            Console.Write("\b");
            Console.Write("\\");
            System.Threading.Thread.Sleep(intervalBetweenMove);
            Console.Write("\b");
            Console.Write("|");
            System.Threading.Thread.Sleep(intervalBetweenMove);
            Console.Write("\b");
        }
        Console.Write(" \n");

        int extraTimeToWaste = (int)((numOfSeconds - (int)numOfSeconds)*1000);
        System.Threading.Thread.Sleep(extraTimeToWaste);
    }

    // Make the getters and setters.
    public string getName(){
        return _name;
    }

    public string getDescription(){
        return _description;
    }

    public int getSessionLength(){
        return _sessionLength;
    }

    public void setName(string name){
        _name = name;
    }

    public void setDescription(string description){
        _description = description;
    }

    public void setSessionLength(int sessionLength){
        this._sessionLength = sessionLength;
    }

}