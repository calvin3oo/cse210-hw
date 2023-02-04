class EternalGoal: Goal{
    public string _type { get; set; } = "Eternal";
    public int _timesCompleted { get; set; }
    public EternalGoal(string _name, string _description, int _completionPoints)
    : base(_name, _description, _completionPoints){
        this._timesCompleted = 0;
    }
    public EternalGoal(string _name, string _description, int _completionPoints, int _timesCompleted)
    : base(_name, _description, _completionPoints){
        this._timesCompleted = _timesCompleted;
    }

    public override int recordCompletion(){
        _timesCompleted++;
        return _completionPoints;
    }

    public override int pointsEverEarned(){
        return _timesCompleted * _completionPoints;
    }
}