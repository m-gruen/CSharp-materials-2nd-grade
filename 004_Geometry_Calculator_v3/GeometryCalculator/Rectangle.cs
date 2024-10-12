namespace GeometryCalculator;

public class Rectangle : Shape
{
    // Constructor
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    public double Width { get; set; }
    public double Height { get; set; }

    public override double Area => Width * Height;

    public override void Scale(double factor)
    {
        // var SqrtFactor = Math.Sqrt(factor); not needed, because the compiler does it automatically
        Width *= CalculateScaleFactor(factor);
        Height *= CalculateScaleFactor(factor);
    }

    public override string ToString()
    {
        return $"Rectangle: Width={Width}, Height={Height}";
    }
}
