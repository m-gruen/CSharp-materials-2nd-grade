using GeometryCalculator.Logic;

Main();

void Main()
{
    bool isValid = false;
    var input = string.Empty;
    do
    {
        System.Console.Write("Enter the type of the geometric figure (1.rectangle, 2.circle, 3.triangle): ");
        input = Console.ReadLine()!;

        isValid = input is "1" or "2" or "3";
    }
    while(!isValid);

    double width = 0, hight = 0, radius = 0;
    double factor = GetInput("Enter Factor: ");

    switch (input)
    {
        case "1":
            width = GetInput("Enter width: ");
            hight = GetInput("Enter hight: ");

            var areaRectangle = GeometryCalculator.Logic.RectangleMath.CalculateArea(width, hight);
            var (scaledWidth, scaledHight) = GeometryCalculator.Logic.RectangleMath.CalculateScaledDimensions(width, hight, factor);

            PrintResultTriangleRectangle(areaRectangle, areaRectangle * factor, scaledWidth, scaledHight, width, hight);
            break;
        case "2":
            radius = GetInput("Enter radius: ");

            var areaCircle = GeometryCalculator.Logic.CircleMath.CalculateArea(radius);
            var scaledRadius = GeometryCalculator.Logic.CircleMath.CalculateScaledDimensions(radius, factor);

            PrintResultCircle(areaCircle, areaCircle * factor, scaledRadius, radius);
            break;
        case "3":
            width = GetInput("Enter width: ");
            hight = GetInput("Enter hight: ");

            var areaTriangle = GeometryCalculator.Logic.TriangleMath.CalculateArea(width, hight);
            var (scaledBaseLength, scaledHeight) = GeometryCalculator.Logic.TriangleMath.CalculateScaledDimensions(width, hight, factor);

            PrintResultTriangleRectangle(areaTriangle, areaTriangle * factor, scaledBaseLength, scaledHeight, width, hight);
            break;
        default:
            break;
    }


}

double GetInput(string message)
{
    double number = 0;

    do
    {
        System.Console.Write(message);
    }
    while (!double.TryParse(Console.ReadLine()!, out number));

    return number;
}

void PrintResultTriangleRectangle(double area, double scaledArea, double scaledWidth, double scaledHight, double Width, double Hight)
{
    System.Console.WriteLine($"Area: {Math.Round(area, 3)} (Width: {Math.Round(Width, 3)} Hight: {Math.Round(Hight, 3)})");
    System.Console.WriteLine($"Scaled Area: {Math.Round(scaledArea, 3)} (Width: {Math.Round(scaledWidth, 3)} Hight: {Math.Round(scaledHight, 3)})");
}

void PrintResultCircle(double area, double scaledArea, double scaledRadius, double radius)
{
    System.Console.WriteLine($"Area: {Math.Round(area, 3)} (Radius: {Math.Round(radius, 3)})");
    System.Console.WriteLine($"Scaled Area: {Math.Round(scaledArea, 3)} (Radius: {Math.Round(scaledRadius, 3)})");
}