namespace GeometryCalculator;

public class Triangle : Shape
{
    // Constructor
    public Triangle(double baseLength, double height)
    {
        BaseLength = baseLength;
        Height = height;
    }
    public double BaseLength { get; set; }
    public double Height { get; set; }
    
    public override double Area => BaseLength * Height / 2;

    public override void Scale(double factor)
    {
        // var SqrtFactor = Math.Sqrt(factor); not needed, because the compiler does it automatically
        BaseLength *= CalculateScaleFactor(factor);
        Height *= CalculateScaleFactor(factor);
    }

    public override string ToString()
    {
        return $"Triangle: BaseLength={BaseLength}, Height={Height}"; 
    }
}
