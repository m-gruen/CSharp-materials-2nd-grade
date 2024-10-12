namespace Adder.Tests;

public class NumberAdderTests
{
    [Fact]
    public void Add_WhenCalledWithValidInput_ShouldAddToSum()
    {
        // Arrange
        var numberAdder = new NumberAdder();
        var expectedSum = 5;

        // Act
        var result = numberAdder.Add(expectedSum);

        // Assert
        Assert.Equal(expectedSum, result);
        Assert.Equal(expectedSum, numberAdder.Sum);
    }

    [Fact]
    public void Add_SumIsInitiallyZero()
    {
        // Arrange, Act
        var numberAdder = new NumberAdder();

        // Assert
        Assert.Equal(0, numberAdder.Sum);
    }

    [Fact]
    public void Add_ThrowsOverflowException_WhenSumExceedsMaxValue()
    {
        // Arrange
        var numberAdder = new NumberAdder();

        // Act
        numberAdder.Add(int.MaxValue);

        // Assert
        Assert.Throws<OverflowException>(() => numberAdder.Add(1));
        // List<string>, List<int>, List<object>
        // Generic Classes
    }
}