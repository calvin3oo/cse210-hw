[Serializable]
class Staff : Person{
    public string _class = "Staff";
    public Staff(string name, string password, string address, string phoneNumber) : base(name, password, address, phoneNumber){
    }

    public override string GetInfo(){
        return base.GetInfo() + ", Address: " + _address + ", Phone Number: " + _phoneNumber;
    }

    public override bool AddAnimal(Shelter shelter, Animal animal){
        if(shelter.AddAnimal(animal)){
            return true;
        }
        else{
            return false;
        }
    }

    public override bool RemoveAnimal(Shelter shelter, Animal animal){
        if(shelter.RemoveAnimal(animal)){
            return true;
        }
        else{
            return false;
        }
    }

    public override bool AddPersonToShelter(Shelter shelter, Person person){
        if(shelter.AddPerson(person)){
            return true;
        }
        else{
            return false;
        }
    }

    public override bool RemovePersonFromShelter(Shelter shelter, Person person){
        if(shelter.RemovePerson(person)){
            return true;
        }
        else{
            return false;
        }
    }
}