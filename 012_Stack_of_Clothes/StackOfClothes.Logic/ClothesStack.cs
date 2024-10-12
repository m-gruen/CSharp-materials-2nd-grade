using System.Globalization;
using System.Text;

namespace StackOfClothes.Logic;

public class ClothesStack
{
    public Box? Top { get; set; } = null;
    public int Movements { get; set; } = 0;
    public int Count { get; set; } = 0;

    public void Push(string name)
    {
        var box = new Box(name) { Under = Top };
        Top = box;
        Movements++;
        Count++;
    }

    public string Pop()
    {
        if (Top == null) { throw new Exception("The stack is empty"); }

        string name = Top.ToString();
        Top = Top.Under;
        Movements++;
        Count--;
        return name;
    }

    public bool TryFind(string name, out int depth)
    {
        depth = 0;
        for (var current = Top; current != null; current = current.Under)
        {
            if (current.ToString() == name) { return true; }
            depth++;
        }
        return false;
    }

    public override string ToString()
    {
        var output = new StringBuilder();

        for (var current = Top; current != null; current = current.Under)
        {
            output.Append(current.ToString());
            if (current.Under != null) { output.Append(", "); }
        }

        return output.ToString().TrimEnd('\n');
    }
}

public class Box(string name)
{
    private string Name { get; } = name;
    public Box? Under { get; set; } = null;
    public override string ToString() => Name;
}
