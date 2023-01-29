using System.Collections;

public class Scripture{
    private static Random random = new Random();
    private string address;
    private List<string> verse;
    private List<int> invicibleIndexes = new List<int>();
    private List<int> visibleIndexes = new List<int>();

    public Scripture(Dictionary<string, string> scripture){
        if(!scripture.ContainsKey("address") || !scripture.ContainsKey("verse"))
            throw new System.ArgumentException("The scripture dictionary must contain the keys 'address' and 'verse'");

        this.verse = new List<string>(scripture["verse"].Split(' '));
        this.address = scripture["address"];

        for(int i = 0; i < this.verse.Count; i++){
            visibleIndexes.Add(i);
        }
    }

    /** 
    * adds a couple of indexes from the 'visible indexes' array into the 'invisible indexes' array
    */
    public void makeWordsDissapear(){
        int numberOfWordsToDissapear = visibleIndexes.Count >= 3 ? 3 : visibleIndexes.Count;

        for(int i = 0; i < numberOfWordsToDissapear; i++){
            int randomIndex = random.Next(0, visibleIndexes.Count);
            int index = (int)visibleIndexes[randomIndex];
            visibleIndexes.RemoveAt(randomIndex);
            invicibleIndexes.Add(index);
        }
    }

    /**
    * @returns true of false if everything in the verse is invisible
    */
    public Boolean isEverythingInvisible(){
        return visibleIndexes.Count == 0;
    }

    /**
    * @returns string with only "_" that is the lenght of the int 'length' 
    */
    private string getUnderCaseString(int length){
        string underCaseString = " ";
        for(int i = 0; i < length; i++){
            underCaseString += "_";
        }
        return underCaseString + " ";
    }

    /** 
    * @returns the string without the invisible words
    */
    public override string ToString(){

        string verse = address + " ";

        for(int i = 0; i < this.verse.Count; i++){
            if(visibleIndexes.Contains(i)){
                verse += this.verse[i] + " ";
            }else{
                verse += getUnderCaseString(this.verse[i].Length);
            }
        }
        return verse;
    }

}