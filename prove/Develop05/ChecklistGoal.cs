class ChecklistGoal: Goal{
    private int _timesCompleted { get; set; }
    private int _numOfTimesToDo { get; set; }
    private int _pointsPerCompletion { get; set; }

    public ChecklistGoal(string name, string description, int completionPoints, int numOfTimesToDo, int pointsPerCompletion)
    : base(name, description, completionPoints){
        _numOfTimesToDo = numOfTimesToDo;
        _pointsPerCompletion = pointsPerCompletion;
    }

    public override string ToString(){
        return GoalUtilities.genericGoalDesc(_name, _description, _completed) + " " + _timesCompleted + "/" + _numOfTimesToDo;
    }
}