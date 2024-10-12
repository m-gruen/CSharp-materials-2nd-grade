namespace GeometryCalculator;

public class Ellipse : Shape
{
    // Constructor
    public Ellipse(double longRadius, double shortRadius)
    {
        LongRadius = longRadius;
        ShortRadius = shortRadius;
    }
    public double LongRadius { get; set; }
    public double ShortRadius { get; set; }

    public override double Area => Math.PI * LongRadius * ShortRadius;

    public override void Scale(double factor)
    {
        // var SqrtFactor = Math.Sqrt(factor);  not needed, because the compiler does it automatically
        LongRadius *= CalculateScaleFactor(factor);
        ShortRadius *= CalculateScaleFactor(factor);
    }

    public override string ToString()
    {
        return $"Ellipse: LongRadius={LongRadius}, ShortRadius={ShortRadius}";
    }
}