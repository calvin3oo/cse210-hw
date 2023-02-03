public class Goal{
    protected string _name { get; set; }
    protected string _description { get; set; }
    protected int _completionPoints { get; set; }
    protected Boolean _completed { get; set; }

    // Constructor
    public Goal(string name, string description, int completionPoints){
        _name = name;
        _description = description;
        _completionPoints = completionPoints;
        _completed = false;
    }

    // Make methods that are to be overridden TODO
    public override string ToString(){
        return GoalUtilities.genericGoalDesc(_name, _description, _completed);
    }

}