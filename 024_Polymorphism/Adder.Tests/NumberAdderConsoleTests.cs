namespace Adder.Tests;

public class NumberAdderConsoleTests
{
    [Fact]
    public void AddingValidNumbers_ShouldPrintSum()
    {
        // Arrange
        var nacm = new NumberAdderConsoleMock(["5", "6", "q"]);

        // Act
        var result = nacm.AggregateEnteredNumbers();

        // Assert
        Assert.Equal(11, result);
        Assert.Equal([
            "Enter numbers, q to quit",
            "The current sum is: 5",
            "The current sum is: 11"
        ], nacm.Outputs);
    }

    [Fact]
    public void AddingWithInvalidInput_ShouldPrintError()
    {
        // Arrange
        var nacm = new NumberAdderConsoleMock(["5", "Blablabal", "q"]);

        // Act
        var result = nacm.AggregateEnteredNumbers();

        // Assert
        Assert.Equal(5, result);
        Assert.Equal([
            "Enter numbers, q to quit",
            "The current sum is: 5",
            "The number you entered is not valid."
        ], nacm.Outputs);
    }

    [Fact]
    public void AddingWithOverflow_ShouldPrintError()
    {
        // Arrange
        var nacm = new NumberAdderConsoleMock(["2147483647", "1", "q"]);

        // Act
        var result = nacm.AggregateEnteredNumbers();

        // Assert
        Assert.Equal(int.MaxValue, result);
        Assert.Equal([
            "Enter numbers, q to quit",
            "The current sum is: 2147483647",
            "The number you entered is too large."
        ], nacm.Outputs);
    }
}