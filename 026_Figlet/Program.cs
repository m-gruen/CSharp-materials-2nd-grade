using WenceyWang.FIGlet;

var renderers = new[]
{
    new TextRenderer(),
    new FigletRenderer(Path.Combine("fonts", "Bloody.flf")),
    new FigletRenderer(Path.Combine("fonts", "3-D.flf")),
    new FigletRenderer(Path.Combine("fonts", "3d.flf")),
    new FigletRenderer(Path.Combine("fonts", "5 Line Oblique.flf")),
};

foreach (var renderer in renderers)
{
    var text = new string[] { "Hello World" };
    var renderedText = renderer.RenderText(text);
    Console.WriteLine(string.Join("\n", renderedText));
}

class TextRenderer
{
    public virtual string[] RenderText(string[] text) => text;
}

class FigletRenderer : TextRenderer
{
    private readonly FIGletFont? font;

    public FigletRenderer(string? fontPath = null)
    {
        if (fontPath != null)
        {
            using var stream = File.OpenRead(fontPath);
            font = new FIGletFont(stream);
        }
    }

    public override string[] RenderText(string[] text)
    {
        var result = new List<string>();
        foreach (var line in text)
        {
            var art = new AsciiArt(line, font);
            result.AddRange(art.ToString().Split('\n'));
        }
        return result.ToArray();
    }
}
