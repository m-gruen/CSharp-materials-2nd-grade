namespace Adder.Tests;

class NumberAdderConsoleMock(string[] inputs) : NumberAdderConsole
{
    public List<string> Outputs { get; } = [];
    private int NumberOfReadLineCommands { get; set; }

    public override void WriteLine(string s)
    {
       Outputs.Add(s);
    }

    public override string ReadLine()
    {
        return inputs[NumberOfReadLineCommands++];
    }
}
