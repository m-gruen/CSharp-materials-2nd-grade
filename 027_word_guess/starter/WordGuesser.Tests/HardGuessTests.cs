namespace WordGuesser.Tests;

public class HardWordGuessMockSingleWord : HardWordGuess
{
    /// <summary>
    /// Gets the word to guess.
    /// </summary>
    /// <remarks>
    /// This method is overriden to return a single, fixed word instead
    /// of a random word. This is useful for testing purposes.
    /// </remarks>
    public override string GetRandomWord() => "Snowspacemobile";
}

public class HardGuessTests
{
    [Fact]
    public void HardWordGuess_CaseSensitive()
    {
        // Use the HardWordGuessMockSingleWord class to test if
        // the Guess method is case-sensitive. Guess the letter "s"
        // and make sure that the occurrence of "S" (uppercase) 
        // was not revealed.

        // Arrange
        var hardWordGuess = new HardWordGuessMockSingleWord();

        // Act
        var result = hardWordGuess.Guess('s');

        // Assert
        Assert.True(result);
        Assert.Equal("____s__________", hardWordGuess.CurrentGuess);
    }

    [Fact]
    public void HardWordGuess_OnlyRevealsFirst()
    {
        // Use the HardWordGuessMockSingleWord class to test if
        // the Guess method reveals only the first occurrence of
        // the guessed letter. Guess the letter "o" and make sure
        // that only the first occurrence is revealed.

        // Arrange 
        var hardWordGuess = new HardWordGuessMockSingleWord();

        // Act
        var result = hardWordGuess.Guess('o');

        // Assert
        Assert.True(result);
        Assert.Equal("__o____________", hardWordGuess.CurrentGuess);
    }
}