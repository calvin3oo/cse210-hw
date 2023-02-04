public class Goal{
    public string _name { get; set; }
    public string _description { get; set; }
    public int _completionPoints { get; set; }
    public Boolean _completed { get; set; }

    // Constructor
    public Goal(string _name, string _description, int _completionPoints){
        this._name = _name;
        this._description = _description;
        this._completionPoints = _completionPoints;
        this._completed = false;
    }

    // Make methods that are to be overridden TODO
    public override string ToString(){
        return GoalUtilities.genericGoalDesc(_name, _description, _completed);
    }

    public virtual int recordCompletion(){
        if(_completed) return 0;

        _completed = true;
        return _completionPoints;
    }

    public virtual int pointsEverEarned(){
        return _completed ? _completionPoints : 0;
    }

}