namespace Roulette.Logic;

public enum MultiNumberBetType
{
    Street,
    Split,
    Square,
    SixLine
}

/// <summary>
/// Represents a multi-number bet on a roulette table.
/// </summary>
/// <remarks>
/// A bet can be constructed even if it is not valid.
/// To check if a bet is valid, call the <see cref="Validate"/> method.
/// </remarks>
public class Bet(MultiNumberBetType betType, HashSet<int> numbers)
{
    /// <summary>
    /// Checks if the bet is valid.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the bet is valid; otherwise, <c>false</c>.
    /// </returns>
    public bool Validate()
    {
        bool isValid = false;

        var possibleNumbers = new PossibleNumbers();

        if(betType == MultiNumberBetType.Street)
        {
            isValid = Contains(possibleNumbers.Streets, numbers);
        }
        else if(betType == MultiNumberBetType.Split)
        {   
            isValid = Contains(possibleNumbers.Splits, numbers);
        }
        else if(betType == MultiNumberBetType.Square)
        {
            isValid = Contains(possibleNumbers.Squares, numbers);
        }
        else if(betType == MultiNumberBetType.SixLine)
        {
            isValid = Contains(possibleNumbers.SixLines, numbers);
        }

        return isValid;
    }

    /// <summary>
    /// Checks if a given set of numbers is in a list of sets of numbers.
    /// </summary>
    /// <param name="list">List of set of numbers in which to search</param>
    /// <param name="numbers">Numbers to search</param>
    /// <returns>
    /// <c>true</c> if the numbers are in the list; otherwise, <c>false</c>.
    /// </returns>
    public static bool Contains(List<HashSet<int>> list, HashSet<int> numbers)
    {

        foreach (var set in list)
        {
            if (set.SetEquals(numbers))
            {
                return true;
            }
        }

        return false;
    }
}