[Serializable]
class Person{
    public string _name;
    public string _password;
    public string _address;
    public string _phoneNumber;

    public Person(string name, string password, string address, string phoneNumber){
        _name = name;
        _password = password;
        _address = address;
        _phoneNumber = phoneNumber;
    }

    public virtual string GetInfo(){
        return "Name: " + _name;
    }

    public bool isLoginCorrect(string name, string password){
        if(password == _password && name == _name){
            return true;
        }
        else{
            return false;
        }
    }

    // Getter for the name
    public string GetName(){
        return _name;
    }

    // Functions to be overridden by subclasses
    public virtual bool AddAnimal(Shelter shelter, Animal animal){
        return false;
    }

    public virtual bool RemoveAnimal(Shelter shelter, Animal animal){
        return false;
    }

    public virtual bool AddPersonToShelter(Shelter shelter, Person person){
        return false;
    }

    public virtual bool RemovePersonFromShelter(Shelter shelter, Person person){
        return false;
    }

    public virtual bool Adopt(Shelter shelter, Animal animal){
        return false;
    }
}