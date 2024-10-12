// BASE CLASS for Circle, Rectangle, Triangle, ...

// abstract = Only for inheritances, cannot be used directly!
public abstract class Shape
{
    public abstract double Area {get;} // All inherited classes must have this property
    public abstract void Scale(double factor); // All inherited classes must have this method

    // protected = only for inherited classes
    protected double CalculateScaleFactor(double factor)
    {
        return Math.Sqrt(factor);
    }

}

// abstract in the base Class
// override in the inherited Class