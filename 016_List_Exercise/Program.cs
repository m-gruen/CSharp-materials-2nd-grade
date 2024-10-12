// List Exercise https://github.com/rstropek/2023-24-2nd/tree/main/homeworks/2024-01-number-list

using static System.Console;

WriteLine("Hello and Welcome to the List Exercise!");

// Part 1:
WriteLine("This is Part 1:");

var inPlace = new InPlace();
inPlace.GenerateNumbers(1, 100);
WriteLine(inPlace.CalculateSum());

inPlace.InsertSumAfterPairs();
WriteLine(inPlace.CalculateSum());

inPlace.RemoveEvenNumbers();
WriteLine(inPlace.CalculateSum());

inPlace.ReplaceWithRunningTotal();
WriteLine(inPlace.CalculateSum());

long result = inPlace.CalculateResult();
WriteLine($"Result: {result}");

WriteLine();

// Part 2:
WriteLine("This is Part 2:");

var list = NewList.GenerateNumbers(1, 100);
WriteLine(NewList.CalculateSum(list));

list = NewList.InsertSumAfterPairs(list);
WriteLine(NewList.CalculateSum(list));

list = NewList.RemoveEvenNumbers(list);
WriteLine(NewList.CalculateSum(list));

list = NewList.ReplaceWithRunningTotal(list);
WriteLine(NewList.CalculateSum(list));

result = NewList.CalculateResult(list);
WriteLine($"Result: {result}");


class InPlace // Part 1
{
    private readonly List<long> Numbers = [];

    public void GenerateNumbers(long start, long end)
    {
        for (long i = start; i <= end; i++) { Numbers.Add(i); }
    }

    public void InsertSumAfterPairs()
    {
        for (int i = 0; i < Numbers.Count - 1; i += 3) { Numbers.Insert(i + 2, Numbers[i] + Numbers[i + 1]); }
    }

    public void RemoveEvenNumbers()
    {
        for (int i = 0; i < Numbers.Count; i++)
        {
            if (Numbers[i] % 2 == 0)
            {
                Numbers.RemoveAt(i);
                i--;
            }
        }
    }

    public void ReplaceWithRunningTotal()
    {
        long runningTotal = 0;
        for (int i = 0; i < Numbers.Count; i++)
        {
            runningTotal += Numbers[i];
            Numbers[i] = runningTotal;
        }
    }

    public long CalculateSum()
    {
        long sum = 0;

        foreach (long number in Numbers) { sum += number; }

        return sum;
    }

    public long CalculateResult()
    {
        return CalculateSum() + CalculateSum() / Numbers.Count;
    }
}

static class NewList // Part 2
{
    // Generate a list of numbers between start and end
    public static List<long> GenerateNumbers(long start, long end)
    {
        List<long> numbers = [];

        for (long i = start; i <= end; i++) { numbers.Add(i); }

        return numbers;
    }

    // Behind each pair of numbers, insert the sum of the number pair.
    public static List<long> InsertSumAfterPairs(List<long> numbers)
    {
        for (int i = 0; i < numbers.Count - 1; i += 3) { numbers.Insert(i + 2, numbers[i] + numbers[i + 1]); }

        return numbers;
    }

    // Remove all even numbers from the list
    public static List<long> RemoveEvenNumbers(List<long> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                numbers.RemoveAt(i);
                i--;
            }
        }

        return numbers;
    }

    // Exchange each number with the running total up until the number.
    public static List<long> ReplaceWithRunningTotal(List<long> numbers)
    {
        long runningTotal = 0;

        for (int i = 0; i < numbers.Count; i++)
        {
            runningTotal += numbers[i];
            numbers[i] = runningTotal;
        }

        return numbers;
    }

    // Calculate the sum of all numbers.
    public static long CalculateSum(List<long> numbers)
    {
        long sum = 0;

        foreach (long number in numbers) { sum += number; }

        return sum;
    }

    // Calculate the mean (rounded to 0 decimals) and the sum of all numbers.
    public static long CalculateResult(List<long> numbers)
    {
        return CalculateSum(numbers) + CalculateSum(numbers) / numbers.Count;
    }
}