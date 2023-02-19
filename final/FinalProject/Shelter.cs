[Serializable]
class Shelter{
    public string _class = "Shelter";
    public List<Animal> _animals { get; set;} = new List<Animal>();
    public List<Person> _people { get; set;} = new List<Person>();
    public string _name { get; set;}

    public Shelter(string name){
        _name = name;
    }

    public bool AddAnimal(Animal animal){
        try{
            _animals.Add(animal);
            return true;
        } catch(Exception e){
            Console.WriteLine(e);
            return false;
        }
    }

    public bool RemoveAnimal(Animal animal){
        try{
            _animals.Remove(animal);
            return true;
        } catch(Exception e){
            Console.WriteLine(e);
            return false;
        }
    }

    public void PrintAnimals(){
        int count = 1;
        foreach(Animal animal in _animals){
            Console.WriteLine(count+". " + animal.GetInfo());
            count++;
        }
    }

    public void PrintSounds(){
        foreach(Animal animal in _animals){
            Console.WriteLine(animal.MakeSound());
        }
    }

    public void PrintInfo(){
        Console.WriteLine("Shelter Name: " + _name);
        Console.WriteLine("Animals:");
        PrintAnimals();
    }

    public void PrintSoundsAndInfo(){
        Console.WriteLine("Shelter Name: " + _name);
        Console.WriteLine("Sounds:");
        PrintSounds();
        Console.WriteLine("Info:");
        PrintAnimals();
    }

    public bool AddPerson(Person person){
        try{
            _people.Add(person);
            return true;
        } catch (Exception e){
            Console.WriteLine(e);
            return false;
        }
    }

    public bool RemovePerson(Person person){
        try{
            _people.Remove(person);
            return true;
        } catch (Exception e){
            Console.WriteLine(e);
            return false;
        }
    }

    public Person GetPerson(string username){
        foreach(Person person in _people){
            if(person.GetName() == username){
                return person;
            }
        }

        return null;
    }

    public List<Person> GetPeople(){
        return _people;
    }

    public List<Animal> GetAnimals(){
        return _animals;
    }

    public void setPeople(List<Person> people){
        _people = people;
    }

    public void setAnimals(List<Animal> animals){
        _animals = animals;
    }

    public int GetAnimalCount(){
        return _animals.Count;
    }

    public int GetPersonCount(){
        return _people.Count;
    }

    public Animal GetAnimal(int index){
        return _animals[index];
    }
}