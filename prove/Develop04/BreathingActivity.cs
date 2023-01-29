class BreathingActivity : Activity{
    private static new string _name = "Breathing Activity";
    private static new string _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    private static int idealBreathingLength = 9;


    public BreathingActivity() : base(_name, _description){

    }

    public void Play(){
        Intro();

        int numOfIntervals = (int)_sessionLength / idealBreathingLength;

        int extraSeconds = _sessionLength % idealBreathingLength;

        float secondsPerInterval;
        if (numOfIntervals == 0) secondsPerInterval = _sessionLength;
        else secondsPerInterval = idealBreathingLength + (float)extraSeconds/numOfIntervals;

        if(numOfIntervals == 0) numOfIntervals = 1;

        for(int i=0; i<numOfIntervals; i++){

            float breatheInTime = secondsPerInterval/3;
            float breatheOutTime = (secondsPerInterval/3) * 2;

            Console.Write("Breath in... ");
            Countdown(breatheInTime);

            Console.Write("Breath out... ");
            Countdown(breatheOutTime);

            Console.WriteLine();
        }

        Outro();
    }
}