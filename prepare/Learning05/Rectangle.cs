public class Rectangle: Shape{
    // Create a private _width and _height variable and add getters and setters
    private double _width;
    private double _height;
    public double Width{
        get{
            return _width;
        }
        set{
            _width = value;
        }
    }
    public double Height{
        get{
            return _height;
        }
        set{
            _height = value;
        }
    }

    // Create a constructor that takes a color and width and height
    public Rectangle(string color, double width, double height): base(color){
        _width = width;
        _height = height;
    }

    // Override the GetArea() method
    public override double GetArea(){
        return _width * _height;
    }
}