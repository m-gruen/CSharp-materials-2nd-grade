using System.Globalization;
using GeometryCalculator;

System.Console.Write("Enter the type of the geometric figure ([r]ectangle, [c]ircle, [t]riangle, [e]llipse): ");
var figureType = Console.ReadLine()!;

Shape myShape;

switch (figureType)
{
    case "r":
    {
        Console.Write("Enter the width of the rectangle: ");
        var width = double.Parse(Console.ReadLine()!);
        Console.Write("Enter the height of the rectangle: ");
        var height = double.Parse(Console.ReadLine()!);

        myShape = new Rectangle(width, height); 
        break;
    }
    case "c":
    {
        Console.Write("Enter the radius of the circle: ");
        var radius = double.Parse(Console.ReadLine()!);
        myShape = new Circle(radius);
        break;
    }
    case "t":
    {
        Console.Write("Enter the base of the triangle: ");
        var baseLength = double.Parse(Console.ReadLine()!);
        Console.Write("Enter the height of the triangle: ");
        var height = double.Parse(Console.ReadLine()!);
        myShape = new Triangle(baseLength, height);
        break;
    }
    case "e":
    {
        Console.Write("Enter the long radius of the ellipse: ");
        var longRadius = double.Parse(Console.ReadLine()!);
        Console.Write("Enter the short radius of the ellipse: ");
        var shortRadius = double.Parse(Console.ReadLine()!);

        if (shortRadius > longRadius)
        {
            System.Console.WriteLine("The short radius cannot be greater than the long radius. Swapping the values.");
            (shortRadius, longRadius) = (longRadius, shortRadius);
        }
        myShape = new Ellipse(longRadius, shortRadius);
        break;
    }
    default:
        Console.WriteLine("Invalid figure type.");
        return;
}

Console.Write("Enter the factor: ");
var factor = double.Parse(Console.ReadLine()!);

System.Console.WriteLine($"The original area of {myShape} is {myShape.Area}");
myShape.Scale(factor);
System.Console.WriteLine($"The new area of {myShape} is {Math.Round(myShape.Area, 3)}");