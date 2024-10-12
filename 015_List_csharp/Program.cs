// <int> is the TYPE PARAMETER
// List is the GENERIC class
List<int> numbers = [1, 2, 3];
List<string> names = ["tim", "tom"];
List<Point> points = [new(1, 2), new(3, 4)];
List<List<int>> listOfLists = [];

numbers.Add(4);

foreach (var n in numbers)
{
    Console.WriteLine(n);
}

Console.WriteLine(numbers[0]);
numbers[0] = 5;

numbers.Insert(0, -1);

numbers.RemoveAt(0);

numbers = [1, 2, 3];
var numbers2 = numbers; // We are making a reference
numbers2[0] = 5;
// What is numbers[0]?
// It is: 5

var numbers3 = numbers.ToList(); // We are making a copy
numbers3[0] = 10;
// What is numbers[0]?
// It is still: 5

// LINQ = Language Integrated Query
var sum = numbers.Sum();
var avg = numbers.Average();
var max = numbers.Max();
var min = numbers.Min();
var first = numbers.First();
var last = numbers.Last();
var count = numbers.Count;
// ... 

record Point(int X, int Y);
