using System.Text.Json;
using System.Text.Json.Nodes;
class Instance{
    private static JsonSerializerOptions JSON_SAVE_OPTIONS = new JsonSerializerOptions { IncludeFields = true };
    private static string SAVE_DIRECTORY = "saves/";
    private static string[] ANIMAL_TYPES = {"Dog", "Cat", "Bird"};
    private static bool PRODUCTION = true;

    protected bool _finished;
    protected string _saveFile;
    protected Shelter _shelter;
    bool loggedIn;
    Person loggedInUser;

    public Instance(string saveFile){
        _finished = false;
        _saveFile = saveFile;
    }
    public void Start(){
        // Check if game has been configured
        if(!GameConfigured() || !LoadGame()){
            // If not, configure game
            ConfigureGame();
        }
        Save();


        while(!_finished){
            Save();

            if(PRODUCTION) Console.Clear();

            string username = PromptAndGetUsername();

            if(username == "quit"){
                _finished = true;
                break;
            }

            Console.Write("Password: ");
            string password = Console.ReadLine();

            // Check if user exists
            Person user = _shelter.GetPerson(username);

            if(user == null){
                Console.WriteLine("User does not exist, please try again.");
                continue;
            }

            // Check if password is correct
            if(!user.isLoginCorrect(username, password)){
                Console.WriteLine("Incorrect password, please try again.");
                continue;
            }

            loggedInUser = user;
            loggedIn = true;

            while(loggedIn){
                Save();

                int choiceNum = LoggedInChoice();
                if(PRODUCTION) Console.Clear();

                switch(choiceNum){
                    case 1: // Logout
                        loggedIn = false;
                        break;
                    case 2: // Print shelter info
                        _shelter.PrintInfo();
                        break;
                    case 3: // Print shelter sounds
                        _shelter.PrintSounds();
                        break;
                    case 4: // Adopt/Add animal
                        if(loggedInUser is Adopter){
                            Animal animal = getAnimalSelection();
                            loggedInUser.Adopt(_shelter, animal);
                        } else if(loggedInUser is Staff){
                            Animal animal = getNewAnimalInformation();
                            loggedInUser.AddAnimal(_shelter, animal);
                        }
                        break;
                    case 5: // Remove animal
                        if(loggedInUser is Staff){
                            Animal animal = getAnimalSelection();
                            loggedInUser.RemoveAnimal(_shelter, animal);
                        }
                        break;
                    case 6: // Add person
                        if(loggedInUser is Staff){
                            Person person = getNewPersonInformation();
                            ((Staff)loggedInUser).AddPersonToShelter(_shelter, person);
                        }
                        break;
                    case 7: // Remove person
                        if(loggedInUser is Staff){
                            Person person = getPersonSelection();
                            loggedInUser.RemovePersonFromShelter(_shelter, person);
                        }
                        break;
                }
            }
        }
    }

    public Person getPersonSelection(){
        Console.WriteLine("Which person would you like to select?");
        int count = 1;
        foreach(Person person in _shelter.GetPeople()){
            Console.WriteLine(count + ". " + person.GetInfo());
            count++;
        }

        int choice = getLineAndValidInt(count-1);

        return _shelter.GetPeople()[choice-1];
    }

    public Person getNewPersonInformation(){
        Console.Write("Name: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        Console.Write("Address: ");
        string address = Console.ReadLine();

        Console.Write("Phone Number: ");
        string phoneNumber = Console.ReadLine();

        Console.Write("What type of person are they (Staff, Admin, or Adopter): ");
        string personType = getLineAndValidPersonType();

        switch(personType.ToLower()){
            case "staff":
                return new Staff(username, password, address, phoneNumber);
            case "admin":
                return new Admin(username, password, address, phoneNumber);
            case "adopter":
                return new Adopter(username, password, address, phoneNumber);
            default:
                return null;
        }
    }

    public string getLineAndValidPersonType(){
        string personType = Console.ReadLine();

        while(!ValidPersonType(personType)){
            Console.Write("What type of person are they (Staff, Admin, or Adopter): ");
            personType = Console.ReadLine();
        }

        return personType;
    }

    public bool ValidPersonType(string personType){
        return personType.ToLower() == "staff" || personType.ToLower() == "admin" || personType.ToLower() == "adopter";
    }

    public int LoggedInChoice(){
        // Prompt user to choose an action
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Logout");
        Console.WriteLine("2. Print shelter info");
        Console.WriteLine("3. Print shelter sounds");
        
        if(loggedInUser is Adopter){
            Console.WriteLine("4. Adopt an animal");

        } else if(loggedInUser is Staff){
            Console.WriteLine("4. Add an animal");
            Console.WriteLine("5. Remove an animal");
            Console.WriteLine("6. Add a person");
            Console.WriteLine("7. Remove a person");
        }

        Console.Write("Choice: ");
        string choice = Console.ReadLine();

        while(!ValidChoice(choice, loggedInUser is Staff ? 7 : 4)){
            Console.Write("Choice: ");
            choice = Console.ReadLine();
        }

        int choiceNum = int.Parse(choice);

        return choiceNum;
    }

    public Animal getNewAnimalInformation(){
        Console.Write("Species (Dog, Cat or Bird): ");
        string species = getLineAndValidSpecies();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Age: ");
        int age = getLineAndValidInt();

        Console.Write("Breed: ");
        string breed = Console.ReadLine();

        switch(species.ToLower()){
            case "dog":
                Console.Write("Fur Color: ");
                string furColor = Console.ReadLine();

                return new Dog(name, age, breed, furColor);
            case "cat":
                Console.Write("Fur Pattern: ");
                string furPattern = Console.ReadLine();

                return new Cat(name, age, breed, furPattern);
            case "bird":
                Console.Write("Feather Color: ");
                string featherColor = Console.ReadLine();

                return new Bird(name, age, breed, featherColor);
            default:
                return null;
        }
    }

    public string getLineAndValidSpecies(){
        string species = Console.ReadLine();

        while(!ValidSpecies(species)){
            Console.Write("Species (Dog, Cat or Bird): ");
            species = Console.ReadLine();
        }

        return species;
    }

    public bool ValidSpecies(string species){
        foreach(string animalType in ANIMAL_TYPES){
            if(animalType.ToLower() == species.ToLower()){
                return true;
            }
        }

        return false;
    }

    public int getLineAndValidInt(int max = int.MaxValue, int min = 0){
        string age = Console.ReadLine();

        while(!int.TryParse(age, out int ageInt)){
            Console.Write("Age: ");
            age = Console.ReadLine();
        }

        return int.Parse(age);
    }


    public Animal getAnimalSelection(){
        _shelter.PrintAnimals();
        Console.Write("Choice: ");
        string choice = Console.ReadLine();

        while(!ValidChoice(choice, _shelter.GetAnimalCount())){
            Console.Write("Choice: ");
            choice = Console.ReadLine();
        }

        int choiceNum = int.Parse(choice);

        return _shelter.GetAnimal(choiceNum-1);
    }

    public bool ValidChoice(string choice, int max){
        // Check if choice is valid
        if(!int.TryParse(choice, out int choiceInt)){
            Console.WriteLine("Invalid choice, please try again.");
            return false;
        }

        if(choiceInt < 1 || choiceInt > max){
            Console.WriteLine("Invalid choice, please try again.");
            return false;
        }

        return true;
    }

    public string PromptAndGetUsername(){
        // Prompt user to login or quit the program
        Console.WriteLine("Welcome to the Animal Shelter! Please login or type 'quit' to exit:");
        Console.Write("Username: ");
        return Console.ReadLine();
    }

    public bool GameConfigured(){
        // Check if save file exists
        if(File.Exists(SAVE_DIRECTORY + _saveFile)){
            return true;
        }
        
        return false;
    }

    public bool Save(){ //TODO This will need more work because of polymorphism
        // Save game to file
        try {
            string json = "{ "
            +   "\"Shelter\": {"
            +       "\"people\":"+ getStrOfPeople() +","
            +       "\"animals\":"+ getStrOfAnimals() +","
            +       "\"name\":\"Shelter\""
            +   "}"
            +"}";
            
            File.WriteAllText(SAVE_DIRECTORY + _saveFile, json);

            return true;
        } catch (Exception e){
            Console.WriteLine("Error saving game: " + e.Message);

            return false;
        }
    }

    public string getStrOfAnimals(){
        // Create a JSON to write to the file
        List<Animal> animals = _shelter.GetAnimals();
        List<string> array = new List<string>();

        for(int i = 0; i < animals.Count; i++){
            Type typeOfObject = animals[i].GetType();

            switch(typeOfObject){
                case Type t when t == typeof(Dog):
                    array.Add(JsonSerializer.Serialize<Dog>((Dog)animals[i], JSON_SAVE_OPTIONS));
                    break;
                case Type t when t == typeof(Cat):
                    array.Add(JsonSerializer.Serialize<Cat>((Cat)animals[i], JSON_SAVE_OPTIONS));
                    break;
                case Type t when t == typeof(Bird):
                    array.Add(JsonSerializer.Serialize<Bird>((Bird)animals[i], JSON_SAVE_OPTIONS));
                    break;
                default:
                    throw new Exception("Invalid animal type: " + typeOfObject);
            }
        }

        return "[" + string.Join(",", array) + "]";
    }

    public string getStrOfPeople(){
        // Create a JSON to write to the file
        List<Person> people = _shelter.GetPeople();
        List<string> array = new List<string>();

        for(int i = 0; i < people.Count; i++){
            Type typeOfObject = people[i].GetType();

            switch(typeOfObject){
                case Type t when t == typeof(Staff):
                    array.Add(JsonSerializer.Serialize<Staff>((Staff)people[i], JSON_SAVE_OPTIONS));
                    break;
                case Type t when t == typeof(Admin):
                    array.Add(JsonSerializer.Serialize<Admin>((Admin)people[i], JSON_SAVE_OPTIONS));
                    break;
                case Type t when t == typeof(Adopter):
                    array.Add(JsonSerializer.Serialize<Adopter>((Adopter)people[i], JSON_SAVE_OPTIONS));
                    break;
                default:
                    throw new Exception("Invalid person type: " + typeOfObject);
            }
        }

        return "[" + string.Join(",", array) + "]";
    }

    public bool LoadGame(){
        // Load game from file
        try {
            // Get the text in the file
            string jsonString = File.ReadAllText(SAVE_DIRECTORY + _saveFile);

            // Read the JSON from the file
            JsonNode file = JsonNode.Parse(jsonString)!;

            JsonObject jsonShelter = file.AsObject()!["Shelter"].AsObject()!;

            // Get the shelter name
            string shelterName = jsonShelter["name"].ToString()!;
            if(!PRODUCTION) Console.WriteLine("Shelter name: " + shelterName);

            // Create a new shelter
            _shelter = new Shelter(shelterName);

            // Get the people
            JsonArray jsonPeople = jsonShelter["people"].AsArray()!;
            List<Person> people = getPeopleListFromJson(jsonPeople);
            _shelter.setPeople(people);

            // Get the animals
            JsonArray jsonAnimals = jsonShelter["animals"].AsArray()!;
            List<Animal> animals = getAnimalsListFromJson(jsonAnimals);
            _shelter.setAnimals(animals);



            return true;
        } catch (Exception e){
            Console.WriteLine("Error loading game: " + e.Message);

            return false;
        }
    }

    public List<Animal> getAnimalsListFromJson(JsonArray jsonAnimals){
        List<Animal> animals = new List<Animal>();

        for(int i = 0; i<jsonAnimals.Count; i++){
            JsonObject jsonAnimal = jsonAnimals[i].AsObject()!;

            string typeOfAnimal = jsonAnimal["_class"].ToString()!;

            switch(typeOfAnimal){
                case "Bird":
                    Bird staff = new Bird(
                        jsonAnimal["Name"].ToString()!,
                        jsonAnimal["Age"].ToString()!,
                        jsonAnimal["Breed"].ToString()!,
                        jsonAnimal["FeatherColor"].ToString()!
                    );
                    animals.Add(staff);
                    break;
                case "Cat":
                    Cat admin = new Cat(
                        jsonAnimal["Name"].ToString()!,
                        jsonAnimal["Age"].ToString()!,
                        jsonAnimal["Breed"].ToString()!,
                        jsonAnimal["FurPattern"].ToString()!
                    );
                    animals.Add(admin);
                    break;
                case "Dog":
                    Dog adopter = new Dog(
                        jsonAnimal["Name"].ToString()!,
                        jsonAnimal["Age"].ToString()!,
                        jsonAnimal["Breed"].ToString()!,
                        jsonAnimal["FurColor"].ToString()!
                    );
                    animals.Add(adopter);
                    break;
                default:
                    throw new Exception("Invalid animal type: " + typeOfAnimal);
            }
        }

        return animals;
    }

    public List<Person> getPeopleListFromJson(JsonArray JsonPeople){
        List<Person> people = new List<Person>();

        for(int i = 0; i < JsonPeople.Count; i++){
            JsonObject jsonPerson = JsonPeople[i].AsObject()!;

            string typeOfPerson = jsonPerson["_class"].ToString()!;

            switch(typeOfPerson){
                case "Staff":
                    Staff staff = new Staff(
                        jsonPerson["_name"].ToString()!,
                        jsonPerson["_password"].ToString()!,
                        jsonPerson["_address"].ToString()!,
                        jsonPerson["_phoneNumber"].ToString()!
                    );
                    people.Add(staff);
                    break;
                case "Admin":
                    Admin admin = new Admin(
                        jsonPerson["_name"].ToString()!,
                        jsonPerson["_password"].ToString()!,
                        jsonPerson["_address"].ToString()!,
                        jsonPerson["_phoneNumber"].ToString()!
                    );
                    people.Add(admin);
                    break;
                case "Adopter":
                    Adopter adopter = new Adopter(
                        jsonPerson["_name"].ToString()!,
                        jsonPerson["_password"].ToString()!,
                        jsonPerson["_address"].ToString()!,
                        jsonPerson["_phoneNumber"].ToString()!
                    );
                    people.Add(adopter);
                    break;
            }
        }

        return people;
    }

    public void ConfigureGame(){
        Console.WriteLine("Welcome to an Animal Shelter Instance! Start configuring this Instance:");

        Console.WriteLine("What is the name of this shelter?");
        string shelterName = Console.ReadLine();
        _shelter = new Shelter(shelterName);
        Console.WriteLine("Shelter name set to: " + shelterName);

        Console.WriteLine("Start by Adding yourself as the admin, from there you can login and add anything else:");
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();
        Console.WriteLine("What is your password?");
        string password = Console.ReadLine();
        Console.WriteLine("What is your address?");
        string address = Console.ReadLine();
        Console.WriteLine("What is your number?");
        string number = Console.ReadLine();

        Person admin = new Admin(name, password, address, number);

        _shelter.AddPerson(admin);

    }

}