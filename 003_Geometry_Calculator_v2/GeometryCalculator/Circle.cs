namespace GeometryCalculator;

public class Circle
{
    // Constructor
    public Circle(double radius)
    {
        Radius = radius;
    } 

    // Property
    public double Radius { get; /* private */ set; } /* Default Value = 0d; */
 
    // Calculated Property
    public double Area => Math.PI * Radius * Radius;

    public void Scale(double factor)
    {
        Radius *= Math.Sqrt(factor);
    }
}
