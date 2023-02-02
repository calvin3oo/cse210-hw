public class Shape{
    //create a _color string variable and add getters and setters
    private string _color;
    public string GetColor(){
        return _color;
    }
    public void SetColor(string color){
        _color = color;
    }

    public Shape(string color){
        _color = color;
    }

    // Create a virtual method for GetArea().
    public virtual double GetArea(){
        return 0;
    }
}