class Circle : Shape
{
    private double pi = 3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679;
    private double radius;
    public Circle(string color, double radius) : base(color)
    {
        this.radius = radius;
    }

    public override double GetArea()
    {
        return pi*radius;
    }
}