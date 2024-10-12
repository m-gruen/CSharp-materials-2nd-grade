namespace GeometryCalculator;

public class Ellipse
{
    // Constructor
    public Ellipse(double longRadius, double shortRadius)
    {
        LongRadius = longRadius;
        ShortRadius = shortRadius;
    }
    public double LongRadius { get; set; }
    public double ShortRadius { get; set; }

    public double Area => Math.PI * LongRadius * ShortRadius;

    public void Scale(double factor)
    {
        var SqrtFactor = Math.Sqrt(factor);
        LongRadius *= SqrtFactor;
        ShortRadius *= SqrtFactor;
    }
}