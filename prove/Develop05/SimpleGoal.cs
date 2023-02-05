using System.Text.Json.Serialization;

class SimpleGoal: Goal{
    public string _type { get; set; } = "Simple";
    public SimpleGoal(string _name, string _description, int _completionPoints)
    : base(_name, _description, _completionPoints){
    }
    [JsonConstructor]
    public SimpleGoal(string _name, string _description, int _completionPoints, Boolean _completed)
    : base(_name, _description, _completionPoints, _completed){
    }
}