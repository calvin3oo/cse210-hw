[Serializable]
class Cat : Animal{
    public string _class = "Cat";
    public string FurPattern { get; set;}

    public Cat(string name, int age, string breed, string furPattern) : base(name, age, breed){
        FurPattern = furPattern;
    }
    
    /**
    * Must be in the order of:
    * Name, Age, Breed, FurPattern
    */
    public Cat(params string[] parameters) : base(parameters){
        FurPattern = parameters[3];
    }

    public override string MakeSound(){
        return "Meow";
    }

    public override string GetInfo(){
        return base.GetInfo() + ", Fur Pattern: " + FurPattern;
    }
}