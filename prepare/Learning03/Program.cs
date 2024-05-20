using System;

class Program
{
    private Fraction _fraction1;
    private Fraction _fraction2;
    private Fraction _fraction3;
    private Fraction _fraction4;
    static void Main(string[] args)
    {
        Program _program = new Program();
        _program.Run();
    }
    private void Run()
    {
        _fraction1 = new Fraction();
        Console.WriteLine(_fraction1.GetFractionString());
        Console.WriteLine(_fraction1.GetDecimalValue());
        _fraction2 = new Fraction(6);
        Console.WriteLine(_fraction2.GetFractionString());
        Console.WriteLine(_fraction2.GetDecimalValue());
        _fraction3 = new Fraction(6, 7);
        Console.WriteLine(_fraction3.GetFractionString());
        Console.WriteLine(_fraction3.GetDecimalValue());
        _fraction4 = new Fraction(1, 3);
        Console.WriteLine(_fraction4.GetFractionString());
        Console.WriteLine(_fraction4.GetDecimalValue());
    }
}