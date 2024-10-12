﻿namespace GeometryCalculator;

public class Triangle
{
    // Constructor
    public Triangle(double baseLength, double height)
    {
        BaseLength = baseLength;
        Height = height;
    }
    public double BaseLength { get; set; }
    public double Height { get; set; }
    
    public double Area => BaseLength * Height / 2;

    public void Scale(double factor)
    {
        var SqrtFactor = Math.Sqrt(factor);
        BaseLength *= SqrtFactor;
        Height *= SqrtFactor;
    }
}
