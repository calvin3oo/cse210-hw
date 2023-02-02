public class Circle: Shape{
    // Create a private _radius variable and add getters and setters
    private double _radius;
    public double Radius{
        get{
            return _radius;
        }
        set{
            _radius = value;
        }
    }

    // Create a constructor that takes a color and radius
    public Circle(string color, double radius): base(color){
        _radius = radius;
    }

    // Override the GetArea() method
    public override double GetArea(){
        return Math.PI * _radius * _radius;
    }
}