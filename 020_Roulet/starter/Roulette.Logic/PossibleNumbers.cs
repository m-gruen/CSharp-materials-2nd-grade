namespace Roulette.Logic;

public class PossibleNumbers
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PossibleNumbers"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor must initialize all properties of this class.
    /// You MUST NOT simply write down all possible numbers. You have to
    /// find a way to calculate the possible bets based on the rules of
    /// Roulette. For a detailed description of how Roulette works, see
    /// https://de.888casino.com/magazine/roulette-strategie-guide/roulette-regeln
    /// </remarks>
    public PossibleNumbers()
    {
        // SingleNumbers
        SingleNumbers.AddRange(Enumerable.Range(0, 37));

        // RedBlack
        RedBlack[1] = Enumerable.Range(1, 36).Except(RedBlack[0]).ToHashSet();

        for (var i = 1; i <= 36; i++)
        {
            // EvenOdd
            EvenOdd[i % 2].Add(i);

            // HighLow
            // HighLow[i <= 18 ? 0 : 1].Add(i);
            HighLow[(i - 1) / 18].Add(i);

            // Dozens
            Dozens[(i - 1) / 12].Add(i);

            // Rows
            Rows[(i - 1) % 3].Add(i);
        }

        for (var i = 1; i < 37; i += 3)
        {
            // Streets
            Streets.Add([i, i + 1, i + 2]);
        }

        for (int i = 1; i < 34; i++)
        {
            // Splits vertical
            Splits.Add([i, i + 3]);
        }

        for (int i = 1; i < 37; i += 3)
        {
            // Splits horizontal
            Splits.Add([i, i + 1]);
            Splits.Add([i + 1, i + 2]);
        }

        for (int i = 1; i < 33; i++)
        {
            // Squares
            if (i % 3 != 0)
            {
                Squares.Add([i, i + 1, i + 3, i + 4]);
            }
        }

        // SixLines
        for (int i = 1; i < 34; i += 3)
        {
            SixLines.Add([i, i + 1, i + 2, i + 3, i + 4, i + 5]);
        }
    }

    /// <summary>
    /// Contains all possible single number bets.
    /// </summary>
    /// <remarks>
    /// This list must contain all possible single number bets
    /// on a roulette table. Each sub-list contains exactly one
    /// number, which is the number of the bet.
    /// </remarks>
    public List<int> SingleNumbers { get; } = [];

    /// <summary>
    /// Contains all possible red and black bets.
    /// </summary>
    /// <remarks>
    /// This list must contain exactly two sub-lists. The first
    /// sub-list contains all red numbers, the second sub-list
    /// contains all black numbers.
    /// </remarks>
    public List<HashSet<int>> RedBlack { get; } = [[1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36], []];

    /// <summary>
    /// Contains all possible even and odd bets.
    /// </summary>
    /// <remarks>
    /// This list must contain exactly two sub-lists. The first
    /// sub-list contains all even numbers, the second sub-list
    /// contains all odd numbers.
    /// </remarks>
    public List<HashSet<int>> EvenOdd { get; } = [[], []];

    /// <summary>
    /// Contains all possible high and low bets.
    /// </summary>
    /// <remarks>
    /// This list must contain exactly two sub-lists. The first
    /// sub-list contains all low numbers (<= 18), the second sub-list
    /// contains all high numbers (>= 19).
    public List<HashSet<int>> HighLow { get; } = [[], []];

    /// <summary>
    /// Contains all possible dozen bets.
    /// </summary>
    /// <remarks>
    /// This list must contain exactly three sub-lists. The first
    /// sub-list contains all numbers in the first dozen (1-12), the second
    /// sub-list contains all numbers in the second dozen (13-24), the third
    /// sub-list contains all numbers in the third dozen (25-36).
    /// </remarks>
    public List<HashSet<int>> Dozens { get; } = [[], [], []];

    /// <summary>
    /// Contains all possible row bets.
    /// </summary>
    /// <remarks>
    /// This list must contain exactly three sub-lists.
    /// Lookup the numbers for each row on a roulette table.
    /// </remarks>
    public List<HashSet<int>> Rows { get; } = [[], [], []];

    /// <summary>
    /// Contains all possible street bets.
    /// </summary>
    /// <remarks>
    /// See https://de.888casino.com/magazine/roulette-strategie-guide/roulette-regeln#street-einsatz-auf-drei-zahlen-auch-trio
    /// for a description.
    /// </remarks>
    public List<HashSet<int>> Streets { get; } = [];

    /// <summary>
    /// Contains all possible split bets.
    /// </summary>
    /// <remarks>
    /// See https://de.888casino.com/magazine/roulette-strategie-guide/roulette-regeln#split
    /// for a description.
    /// </remarks>
    public List<HashSet<int>> Splits { get; } = [];

    /// <summary>
    /// Contains all possible square bets.
    /// </summary>
    /// <remarks>
    /// See https://de.888casino.com/magazine/roulette-strategie-guide/roulette-regeln#corner-square-einsatz-auf-vier-zahlen
    /// for a description.
    /// </remarks>
    public List<HashSet<int>> Squares { get; } = [];

    /// <summary>
    /// Contains all possible six line bets.
    /// </summary>
    /// <remarks>
    /// See https://de.888casino.com/magazine/roulette-strategie-guide/roulette-regeln#der-linien-einsatz-sechs-zahlen-einsatz-oder-sechser-linien-einsatz
    /// for a description.
    /// </remarks>
    public List<HashSet<int>> SixLines { get; } = [];
}
