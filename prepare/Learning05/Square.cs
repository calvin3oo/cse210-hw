public class Square: Shape{
    // Create a private _side variable and add getters and setters
    private double _side;
    public double SideLength{
        get{
            return _side;
        }
        set{
            _side = value;
        }
    }

    // Create a constructor that takes a color and sideLength
    public Square(string color, double sideLength): base(color){
        _side = sideLength;
    }

    // Override the GetArea() method
    public override double GetArea(){
        return _side * _side;
    }
}