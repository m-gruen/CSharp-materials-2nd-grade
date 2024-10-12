using Garage.Logic;

Console.OutputEncoding = System.Text.Encoding.Default;

System.Console.WriteLine("What do you want to do?");
System.Console.WriteLine("1) Enter a car entry");
System.Console.WriteLine("2) Enter a car exit");
System.Console.WriteLine("3) Generate report");
System.Console.WriteLine("4) Exit");


var garage = new Garage.Logic.Garage();

string input;
do
{
    System.Console.Write("Your selection: ");
    input = System.Console.ReadLine()!;

    switch (input)
    {
        case "1":
            System.Console.Write("Enter parking spot number: ");
            int parkingSpotNumberInput = int.Parse(System.Console.ReadLine()!);
            if (garage.IsOccupied(parkingSpotNumberInput)) { System.Console.WriteLine("Parking spot is occupied!"); break; }
            System.Console.Write("Enter license plate: ");
            string licensePlateInput = System.Console.ReadLine()!;
            System.Console.Write("Enter entry date/time: ");
            DateTime entryDateTimeInput = DateTime.Parse(System.Console.ReadLine()!);

            garage.Occupy(parkingSpotNumberInput, licensePlateInput, entryDateTimeInput);
            break;
        case "2":
            System.Console.Write("Enter parking spot number: ");
            int parkingSpotNumberExit = int.Parse(System.Console.ReadLine()!);
            if (!garage.IsOccupied(parkingSpotNumberExit)) { System.Console.WriteLine("Parking spot is not occupied!"); break; }
            System.Console.Write("Enter exit date/time: ");
            DateTime exitDateTimeInput = DateTime.Parse(System.Console.ReadLine()!);

            System.Console.WriteLine($"Costs: {garage.Exit(parkingSpotNumberExit, exitDateTimeInput)}€");
            break;
        case "3":
            System.Console.WriteLine(garage.GenerateReport());
            break;
        case "4":
            System.Console.WriteLine("Good bye!");
            return;
        default:
            System.Console.WriteLine("Wrong input try again ...");
            break;
    }
    System.Console.WriteLine();
}
while (true);
