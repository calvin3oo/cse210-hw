//create the fraction class
public class Fraction
{
    //declare the numerator and denominator
    private int _top;
    private int _bottom;

    //create the constructor
    public Fraction(int numerator, int denominator)
    {
        this._top = numerator;
        this._bottom = denominator;
    }

    //create the constructor for whole numbers
    public Fraction(int wholeNumber)
    {
        this._top = wholeNumber;
        this._bottom = 1;
    }
    
    //create the top getter and setter
    public int GetTop()
    {
        return this._top;
    }

    public void SetTop(int top)
    {
        this._top = top;
    }

    //create the bottom getter and setter
    public int GetBottom()
    {
        return this._bottom;
    }

    public void SetBottom(int bottom)
    {
        this._bottom = bottom;
    }

    //create the GetDecimalValue method
    public double GetDecimalValue()
    {
        return (double)this._top / this._bottom;
    }

    //create the add method
    public Fraction Add(Fraction fraction)
    {
        int newNumerator = this._top * fraction._bottom + fraction._top * this._bottom;
        int newDenominator = this._bottom * fraction._bottom;
        return new Fraction(newNumerator, newDenominator);
    }

    //create the subtract method
    public Fraction Subtract(Fraction fraction)
    {
        int newNumerator = this._top * fraction._bottom - fraction._top * this._bottom;
        int newDenominator = this._bottom * fraction._bottom;
        return new Fraction(newNumerator, newDenominator);
    }

    //create the multiply method
    public Fraction Multiply(Fraction fraction)
    {
        int newNumerator = this._top * fraction._top;
        int newDenominator = this._bottom * fraction._bottom;
        return new Fraction(newNumerator, newDenominator);
    }

    //create the divide method
    public Fraction Divide(Fraction fraction)
    {
        int newNumerator = this._top * fraction._bottom;
        int newDenominator = this._bottom * fraction._top;
        return new Fraction(newNumerator, newDenominator);
    }

    //create the to string method
    public override string ToString()
    {
        return this._top + "/" + this._bottom;
    }
    public string GetFractionString()
    {
        return this._top + "/" + this._bottom;
    }
}