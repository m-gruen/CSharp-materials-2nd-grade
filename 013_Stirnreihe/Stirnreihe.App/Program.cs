using Stirnreihe.Logic;
using static System.Console;

try
{
    WriteLine(""" 
    Welcome to the Stirnreihe World Record App! What do you want to do?
    1) Add a person to the line
    1b) Add a person to the line (sorted)
    2) Print the line
    3) Clear the line
    4) Remove a person from the line
    5) Sort the line
    6) Exit
    """);

    var line = new LineOfPeople();
    var choice = string.Empty;
    do
    {
        Write("Your choice: ");
        choice = ReadLine()!;
        WriteLine();

        switch (choice)
        {
            case "1":
            case "1b":
                Write("First name: ");
                var firstName = ReadLine()!;
                Write("Last name: ");
                var lastName = ReadLine()!;
                Write("Height in cm: ");
                var height = int.Parse(ReadLine()!);

                var person = new Person(firstName, lastName, height);
                if (choice == "1") { line.AddToFront(person); }
                else { line.AddSorted(person); }
                break;
            case "2":
                WriteLine(line);
                break;
            case "3":
                line.Clear();
                WriteLine("The line has been cleared.");
                break;
            case "4":
                Write("Index: ");
                var index = int.Parse(ReadLine()!);

                line.RemovePersonAt(index);
                break;
            case "5":
                line.Sort();
                WriteLine("The line has been sorted.");
                break;
            case "6":
                break;
            default:
                WriteLine("Invalid choice!");
                break;
        }
        WriteLine();
    }
    while (choice != "6");
}
catch (Exception ex)
{
    WriteLine(ex.Message);
}
