[Serializable]
class Dog : Animal{
    public string _class = "Dog";
    public string FurColor { get; set;}

    public Dog(string name, int age, string breed, string furColor) : base(name, age, breed){
        FurColor = furColor;
    }

    /**
    * Must be in the order of:
    * Name, Age, Breed, FurColor
    */
    public Dog(params string[] parameters) : base(parameters){
        FurColor = parameters[3];
    }

    public override string MakeSound(){
        return "Woof";
    }

    public override string GetInfo(){
        return base.GetInfo() + ", Fur Color: " + FurColor;
    }
}