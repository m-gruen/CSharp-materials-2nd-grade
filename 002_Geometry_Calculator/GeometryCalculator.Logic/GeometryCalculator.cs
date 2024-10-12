namespace GeometryCalculator.Logic;

public static class RectangleMath 
{
    public static double CalculateArea(double width, double height)
    {
        return width * height;
    }

    public static (double width, double height) CalculateScaledDimensions(double width, double height, double factor)
    {
        var sqrt = Math.Sqrt(factor);

        return (sqrt * width, sqrt * height);
    }
}

public static class CircleMath 
{
    public static double CalculateArea(double radius)
    {
        return Math.PI * radius * radius;
    }
    public static double CalculateScaledDimensions(double radius, double factor)
    {
        var sqrt = Math.Sqrt(factor);

        return radius * sqrt;
    }
}

public static class TriangleMath 
{
    public static double CalculateArea(double baseLength, double height)
    {
        return (baseLength * height) / 2;
    }

    public static (double baseLength, double height) CalculateScaledDimensions(double baseLength, double height, double factor)
    {
        var sqrt = Math.Sqrt(factor);

        return (sqrt * baseLength, sqrt * height);
    }
}

