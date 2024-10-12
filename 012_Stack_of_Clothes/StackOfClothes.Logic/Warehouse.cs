using System.Globalization;
using System.Text;

namespace StackOfClothes.Logic;

public class Warehouse
{
    private ClothesStack[] Stacks { get; set; } = new ClothesStack[5];
    public Warehouse()
    {
        for (int i = 0; i < Stacks.Length; i++) { Stacks[i] = new(); }
    }

    public void Incoming(string name, ClothesStack? stackAvoid = null)
    {
        int min = int.MaxValue;
        int lowestStack = -1;
        for (int i = 0; i < Stacks.Length; i++)
        {
            if (Stacks[i].Count < min && Stacks[i] != stackAvoid)
            {
                min = Stacks[i].Count;
                lowestStack = i;
            }
        }
        Stacks[lowestStack].Push(name);
    }

    public void Shipping(string name)
    {
        int min = int.MaxValue;
        int lowestStack = -1;
        for (int i = 0; i < Stacks.Length; i++)
        {
            if (Stacks[i].TryFind(name, out int depth) && depth < min)
            {
                min = depth;
                lowestStack = i;
            }
        }

        if (lowestStack == -1) { throw new Exception("The shipping Box was not found!"); }

        var stack = Stacks[lowestStack];
        for (int i = 0; i < min; i++)
        {
            Incoming(stack.Pop(), stack); // This line counts as one movement only, but the Program will increment the movement twice.
            stack.Movements--; // This line will decrement the movement counter and the movement counter will be correct.
        }

        stack.Pop();
    }

    public int Movements() => Stacks.Sum(stack => stack.Movements);

    public override string ToString()
    {
        var output = new StringBuilder();
        for (int i = 0; i < Stacks.Length; i++)
        {
            output.Append($"Stack {i}: {Stacks[i]}\n");
        }
        return output.ToString().TrimEnd('\n');
    }
}