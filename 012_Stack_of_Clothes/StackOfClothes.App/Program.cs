using StackOfClothes.Logic;
using static System.Console;

var path = @"C:\Users\MarkG\Dropbox\HTL_Leonding\2_Klasse\Programmieren\CSharp\012_Stack_of_Clothes\StackOfClothes.App\operations_long.txt";

var warehouse = new Warehouse();

var lines = File.ReadAllLines(path);

foreach (var line in lines)
{
    var parts = line.Split(' ');

    switch (parts[0])
    {
        case "incoming":
            warehouse.Incoming(parts[1]);
            break;
        case "shipping":
            warehouse.Shipping(parts[1]);
            break;
    }

    WriteLine(line);
    WriteLine(warehouse);
    WriteLine($"Box movements: {warehouse.Movements()}");
    WriteLine();
}

WriteLine($"Total box movements: {warehouse.Movements()}");
