namespace WordGuesser.Tests;

public class EasyWordGuessMockSingleWord : EasyWordGuess
{
    /// <summary>
    /// Gets the word to guess.
    /// </summary>
    /// <remarks>
    /// This method is overriden to return a single, fixed word instead
    /// of a random word. This is useful for testing purposes.
    /// </remarks>
    public override string GetRandomWord() => "Snowmobile";
}

public class EasyWordGuessMockShort : EasyWordGuess
{
    /// <summary>
    /// Gets the word to guess.
    /// </summary>
    /// <remarks>
    /// This method is overriden to return a single, fixed word instead
    /// of a random word. The word is short and only contains three
    /// different letters.
    public override string GetRandomWord() => "Eat";
}

public class EasyGuessTests
{
    [Fact]
    public void EasyWordGuess_InitializesCurrentGuess_NormalWord()
    {
        // Use the EasyWordGuessMockSingleWord class to test if
        // the CurrentGuess property is initialized correctly.
        // The test makes sure that exactly three different letters
        // are revealed in the initial guess.

        // Arrange
        var easyWordGuess = new EasyWordGuessMockSingleWord();

        // Act
        var revealedLettersCount = easyWordGuess.CurrentGuess.ToLower().Distinct().Count(char.IsLetter);
        
        // Assert
        Assert.Equal(3, revealedLettersCount);
    }

    [Fact]
    public void EasyWordGuess_InitializesCurrentGuess_ShortWord()
    {
        // Use the EasyWordGuessMockShort class to test if
        // the CurrentGuess property is initialized correctly.
        // The test makes sure that the initial guess contains only
        // underscores because the word to guess contains less than
        // four different letters.

        // Arrange, Act
        var easyWordGuess = new EasyWordGuessMockShort();

        // Assert
        Assert.Equal("___", easyWordGuess.CurrentGuess);
        Assert.Equal(0, easyWordGuess.CurrentGuess.Count(char.IsLetter));
    }
}