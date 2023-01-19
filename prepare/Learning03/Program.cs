using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction frac = new Fraction(1, 3);
        Fraction whole = new Fraction(3);

        Console.WriteLine("Fraction Frac: {0}", frac.GetDecimalValue());
        Console.WriteLine("Whole Str: {0}", whole.GetFractionString());
        Console.WriteLine("Whole Frac: {0}", whole.GetDecimalValue());
        Console.WriteLine("Whole Str: {0}", whole.GetFractionString());


    }
}