[Serializable]
class Adopter: Person{
    public string _class = "Adopter";
    public Adopter(string name, string password, string address, string phoneNumber) : base(name, password, address, phoneNumber){
    }

    public override string GetInfo(){
        return base.GetInfo() + ", Address: " + _address + ", Phone Number: " + _phoneNumber;
    }

    public override bool Adopt(Shelter shelter, Animal animal){
        if(shelter.RemoveAnimal(animal)){
            Console.WriteLine("Congratulations! You have adopted " + animal.GetInfo() + "!");
            return true;
        }
        else{
            return false;
        }
    }
}