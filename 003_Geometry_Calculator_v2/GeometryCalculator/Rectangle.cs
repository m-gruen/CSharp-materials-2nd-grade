namespace GeometryCalculator;

public class Rectangle
{
    // Constructor
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    public double Width { get; set; }
    public double Height { get; set; }

    public double Area => Width * Height;

    public void Scale(double factor)
    {
        var SqrtFactor = Math.Sqrt(factor);
        Width *= SqrtFactor;
        Height *= SqrtFactor;
    }
}
