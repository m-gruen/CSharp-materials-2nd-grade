namespace Adder;

public class NumberAdder
{
    public int Sum { get; private set; }

    public int Add(int value)
    {
        return checked(Sum += value);
    }
}
