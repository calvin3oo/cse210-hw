[Serializable]
class Admin: Staff{
    public new string _class = "Admin";
    public Admin(string name, string password, string address, string number): base(name, password, address, number){
    }

    public override string GetInfo(){
        return "Admin: " + base.GetInfo();
    }
}