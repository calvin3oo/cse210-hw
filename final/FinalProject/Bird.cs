[Serializable]
class Bird: Animal{
    public string _class = "Bird";
    public string FeatherColor { get; set;}

    public Bird(string name, int age, string breed, string featherColor) : base(name, age, breed){
        FeatherColor = featherColor;
    }
    
    /**
    * Must be in the order of:
    * Name, Age, Breed, FeatherColor
    */
    public Bird(params string[] parameters) : base(parameters){
        FeatherColor = parameters[3];
    }

    public override string MakeSound(){
        return "Chirp";
    }

    public override string GetInfo(){
        return base.GetInfo() + ", Color: " + FeatherColor ;
    }
}