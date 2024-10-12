using RestaurantQueue.Logic;
using static System.Console;

string path = @"C:\Users\MarkG\Dropbox\HTL_Leonding\2_Klasse\Programmieren\CSharp\011_Restaurant_Queue\RestaurantQueue.App\queue.csv";

WriteLine("""
    What do you want to do?
    1) Add a customer to the queue
    2) Seat the next customer
    3) Display the queue
    4) Save the queue to queue.csv
    5) Load the queue from queue.csv
    6) Remove customer from the queue

    """);

var queue = new RestaurantQueue.Logic.RestaurantQueue();
while (true)
{
    Write("Your choice: ");
    string input = System.Console.ReadLine()!;

    switch (input)
    {
        case "1":
            {
                Write("Enter customer name: ");
                string name = ReadLine()!;
                Write("Enter customer phone number: ");
                string phoneNumber = ReadLine()!;

                queue.Add(name, phoneNumber);
                break;
            }
        case "2":
            WriteLine(queue.Seat());
            break;
        case "3":
            WriteLine(queue.Display());
            break;
        case "4":
            WriteLine(queue.Save(path));
            break;
        case "5":
            WriteLine(queue.Load(path));
            break;
        case "6":
            {
                Write("Enter customer name: ");
                string name = ReadLine()!;

                WriteLine(queue.Remove(name));
                break;
            }
        default:
            WriteLine("Invalid choice");
            break;
    }
    System.Console.WriteLine();
}
