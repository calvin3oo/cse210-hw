class SimpleGoal: Goal{
    public string _type { get; set; } = "Simple";
    public SimpleGoal(string _name, string _description, int _completionPoints)
    : base(_name, _description, _completionPoints){
    }
}