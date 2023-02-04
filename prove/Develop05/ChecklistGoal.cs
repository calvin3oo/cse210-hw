class ChecklistGoal: Goal{
    public string _type { get; set; } = "Checklist";
    public int _timesCompleted { get; set; }
    public int _numOfTimesToDo { get; set; }
    public int _pointsPerCompletion { get; set; }

    public ChecklistGoal(string _name, string _description, int _completionPoints, int _numOfTimesToDo, int _pointsPerCompletion)
    : base(_name, _description, _completionPoints){
        this._numOfTimesToDo = _numOfTimesToDo;
        this._pointsPerCompletion = _pointsPerCompletion;
    }

    public override string ToString(){
        return GoalUtilities.genericGoalDesc(_name, _description, _completed) + " " + _timesCompleted + "/" + _numOfTimesToDo;
    }

    public override int recordCompletion(){
        if(_completed) return 0;

        _timesCompleted++;

        if(_timesCompleted >= _numOfTimesToDo){
            _completed = true;
        }

        return _completed ? _completionPoints : _pointsPerCompletion;
    }

    public override int pointsEverEarned(){
        int timesEarnedBeforeBonus = _completed ? _timesCompleted-1 : _timesCompleted;

        return _timesCompleted * _pointsPerCompletion + (_completed? _completionPoints : 0);
    }
}