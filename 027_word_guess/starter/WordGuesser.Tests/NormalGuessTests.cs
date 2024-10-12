using System.Globalization;

namespace WordGuesser.Tests;

public class WordGuessMockSingleWord : WordGuess
{
    /// <summary>
    /// Gets the word to guess.
    /// </summary>
    /// <remarks>
    /// This method is overriden to return a single, fixed word instead
    /// of a random word. This is useful for testing purposes.
    /// </remarks>
    public override string GetRandomWord() => "Test";
}

public class WordGuessMockWordGroup : WordGuess
{
    /// <summary>
    /// Gets the word to guess.
    /// </summary>
    /// <remarks>
    /// This method is overriden to return a fixed group of words instead
    /// of a random word. This is useful for testing purposes.
    /// </remarks>
    public override string GetRandomWord() => "Test Test";
}

public class NormalGuessTests
{
    [Fact]
    public void WordGuess_InitializesCurrentGuess_SingleWord()
    {
        // Use the WordGuessMockSingleWord class to test if 
        // the CurrentGuess property is initialized correctly.

        // Arrange, Act
        var wordGuess = new WordGuessMockSingleWord();

        // Assert
        Assert.Equal("____", wordGuess.CurrentGuess);
    }

    [Fact]
    public void WordGuess_InitializesCurrentGuess_WordGroup()
    {
        // Use the WordGuessMockWordGroup class to test if
        // the CurrentGuess property is initialized correctly when
        // the word to guess is a group of words.

        // Arrange, Act
        var wordGuess = new WordGuessMockWordGroup();

        // Assert
        Assert.Equal("____ ____", wordGuess.CurrentGuess);
    }

    [Fact]
    public void WordGuess_Guess_ReturnsTrue()
    {
        // Use the WordGuessMockSingleWord class to test if
        // the Guess method returns true when the guessed letter is in the word.
        // Use the letter "t" to also verify if the method is case-insensitive
        // and replaces all occurrences of the letter in the word.

        // Arrange
        var wordGuess = new WordGuessMockSingleWord();

        // Act
        var result = wordGuess.Guess('t');

        // Assert
        Assert.True(result);
        Assert.Equal("T__t", wordGuess.CurrentGuess);
    }

    [Fact]
    public void WordGuess_Guess_ReturnsFalse()
    {
        // Use the WordGuessMockSingleWord class to test if
        // the Guess method returns false when the guessed letter is not in the word.

        // Arrange
        var wordGuess = new WordGuessMockSingleWord();

        // Act
        var result = wordGuess.Guess('z');

        // Assert
        Assert.False(result);
        Assert.Equal("____", wordGuess.CurrentGuess);
    }
}