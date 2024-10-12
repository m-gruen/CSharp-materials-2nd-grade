using System.Globalization;
using GeometryCalculator;

System.Console.Write("Enter the type of the geometric figure ([r]ectangle, [c]ircle, [t]riangle, [e]llipse): ");
var figureType = Console.ReadLine()!;

double width = 0d, height = 0d, radius = 0d, baseLength = 0d, longRadius = 0d, shortRadius = 0d;
switch (figureType)
{
    case "r":
        Console.Write("Enter the width of the rectangle: ");
        width = double.Parse(Console.ReadLine()!);
        Console.Write("Enter the height of the rectangle: ");
        height = double.Parse(Console.ReadLine()!);
        break;
    case "c":
        Console.Write("Enter the radius of the circle: ");
        radius = double.Parse(Console.ReadLine()!);
        break;
    case "t":
        Console.Write("Enter the base of the triangle: ");
        baseLength = double.Parse(Console.ReadLine()!);
        Console.Write("Enter the height of the triangle: ");
        height = double.Parse(Console.ReadLine()!);
        break;
    case "e":
        Console.Write("Enter the long radius of the ellipse: ");
        longRadius = double.Parse(Console.ReadLine()!);
        Console.Write("Enter the short radius of the ellipse: ");
        shortRadius = double.Parse(Console.ReadLine()!);

        if (shortRadius > longRadius)
        {
            System.Console.WriteLine("The short radius cannot be greater than the long radius. Swapping the values.");
            (shortRadius, longRadius) = (longRadius, shortRadius);
        }
        break;
    default:
        Console.WriteLine("Invalid figure type.");
        return;
}

Console.Write("Enter the factor: ");
var factor = double.Parse(Console.ReadLine()!);

switch (figureType)
{
    case "r":
        {
            // var area = RectangleMath.CalculateArea(width, height);
            // Console.WriteLine($"The original area of the rectangle is {area}.");
            // var (scaledWidth, scaledHeight) = RectangleMath.CalculateScaledDimensions(width, height, factor);
            // Console.WriteLine($"The new area of the rectangle with width = {scaledWidth} and height = {scaledHeight} is {Math.Round(RectangleMath.CalculateArea(scaledWidth, scaledHeight), 3)}.");

            var rect = new Rectangle(width, height); // Object Instantiation
            System.Console.WriteLine($"The original area of the rectangle is {rect.Area}.");
            rect.Scale(factor);
            System.Console.WriteLine($"The new area of the rectangle with width = {rect.Width} and height = {rect.Height} is {Math.Round(rect.Area, 3)}.");
            break;
        }
    case "c":
        {
            var circle = new Circle(radius); // Object Instantiation
            System.Console.WriteLine($"The original area of the circle is {circle.Area}.");
            circle.Scale(factor);
            System.Console.WriteLine($"The new area of the circle with radius = {circle.Radius} is {Math.Round(circle.Area, 3)}.");
            break;
        }
    case "t":
        {
            var triangle = new Triangle(baseLength, height);
            System.Console.WriteLine($"The original are of the triangle is {triangle.Area}.");
            triangle.Scale(factor);
            System.Console.WriteLine($"The new area of the triangle with base = {triangle.BaseLength} and height = {triangle.Height} is {Math.Round(triangle.Area, 3)}.");
            break;
        }
    case "e":
        {
            var ellipse = new Ellipse(longRadius, shortRadius);
            System.Console.WriteLine($"The original area of the ellipse is {ellipse.Area}.");
            ellipse.Scale(factor);
            System.Console.WriteLine($"The new area of the ellipse with long radius = {ellipse.LongRadius} and short radius = {ellipse.ShortRadius} is {Math.Round(ellipse.Area, 3)}.");
            break;
        }
    default:
        Console.WriteLine("Invalid figure type.");
        break;
}
