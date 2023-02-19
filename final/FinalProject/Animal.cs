[Serializable]
class Animal{
    public string Name { get; set;}
    public int Age { get; set;}
    public string Breed { get; set;}

    public Animal(string name, int age, string breed){
        Name = name;
        Age = age;
        Breed = breed;
    }

    /**
    * Must be in the order of:
    * Name, Age, Breed
    */
    public Animal(params string[] parameters){
        Name = parameters[0];
        Age = int.Parse(parameters[1]);
        Breed = parameters[2];
    }

    public virtual string MakeSound(){
        return "Generic animal sound";
    }

    public virtual string GetInfo(){
        return "Name: " + Name + ", Age: " + Age + ", Breed: " + Breed;
    }
}