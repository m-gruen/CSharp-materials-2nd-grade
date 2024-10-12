// Shape
// - Draw-methode
// - "Stroke" (Color, Symbol)

// Point - Coordinate (X / Y)
// Line - Coordinate (2x X / Y)
// Polygon - Multiple Lines
// Triangle - Three Lines
// Rectangle - Four Lines
// Square - Four Lines (Special Rectangle)
// Ellipse - Some lines ("tesselation" of lines)
// Circle - Special Ellipse

var stroke = new Stroke(ConsoleColor.White, ConsoleColor.Black, ' ');
List<Shape> shapes = [
    // new Point(10, 10, stroke),
    // new Point(new(15, 15), stroke),
    // new Point(20, 15, stroke),
    // new Line(new(2, 2), new(10, 3), stroke),

    // Diamond
    new Polygon([new(10, 5), new(15, 10), new(10, 15), new(5, 10)], stroke),
];

Console.CursorVisible = false;
Console.BackgroundColor = ConsoleColor.Black;
Console.Clear();
foreach (Shape shape in shapes)
{
    shape.Draw();
}
Console.ReadKey();

record struct Stroke(ConsoleColor BackgroundColor, ConsoleColor ForegroundColor, char Symbol);
record struct Coordinate(int X, int Y);

abstract class Shape(Stroke stroke)
{
    public Stroke Stroke { get; set; } = stroke;

    public abstract void Draw();
}

class Point(Coordinate position, Stroke stroke) : Shape(stroke)
{
    public Point(int x, int y, Stroke stroke) : this(new Coordinate(x, y), stroke) { }
    public override void Draw()
    {
        Console.SetCursorPosition(position.X, position.Y);
        Console.BackgroundColor = Stroke.BackgroundColor;
        Console.ForegroundColor = Stroke.ForegroundColor;
        Console.Write(Stroke.Symbol);
    }
}

class Line(Coordinate start, Coordinate end, Stroke stroke) : Shape(stroke)
{
    public override void Draw()
    {
        // Draw starting point
        Console.SetCursorPosition(start.X, start.Y);
        Console.BackgroundColor = Stroke.BackgroundColor;
        Console.ForegroundColor = Stroke.ForegroundColor;
        Console.Write(Stroke.Symbol);

        // Draw intermediate points
        int dx = end.X - start.X;
        int dy = end.Y - start.Y;
        int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
        float xIncrement = dx / (float)steps;
        float yIncrement = dy / (float)steps;
        float x = start.X;
        float y = start.Y;
        for (int i = 0; i < steps; i++)
        {
            x += xIncrement;
            y += yIncrement;
            Console.SetCursorPosition((int)Math.Round(x), (int)Math.Round(y));
            Console.BackgroundColor = Stroke.BackgroundColor;
            Console.ForegroundColor = Stroke.ForegroundColor;
            Console.Write(Stroke.Symbol);
        }

        // Draw ending point
        Console.SetCursorPosition(end.X, end.Y);
        Console.BackgroundColor = Stroke.BackgroundColor;
        Console.ForegroundColor = Stroke.ForegroundColor;
        Console.Write(Stroke.Symbol);
    }
}

class Polygon(Coordinate[] points, Stroke stroke) : Shape(stroke)
{
    public override void Draw()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Coordinate start = points[i];
            Coordinate end = points[(i + 1) % points.Length];
            new Line(start, end, stroke).Draw();
        }
    }
}

class Rectangle(Coordinate topLeft, Coordinate bottomRight, Stroke stroke)
    : Polygon(
        [topLeft,
        new(topLeft.X, bottomRight.Y),
        bottomRight,
        new(bottomRight.X, topLeft.Y)],
        stroke)
{ }