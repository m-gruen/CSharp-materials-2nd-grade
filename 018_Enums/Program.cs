const int WAGON_PASSANGER = 1;
const int WAGON_LOCOMOTIVE = 2;
// ...

var myWagon = WAGON_LOCOMOTIVE;
var myNewWagon = WagonType.Locomotive;

System.Console.WriteLine(myWagon);
System.Console.WriteLine(myNewWagon);
System.Console.WriteLine((int)myNewWagon);

WagonType myOtherWagon = (WagonType)5;
// This is possible and can crash the program
// WagonType myOtherWagon = (WagonType)99; ! Not Good !
System.Console.WriteLine(myOtherWagon);

var fileMode = FileMode.Read | FileMode.Write;

System.Console.WriteLine(fileMode);

fileMode = (FileMode)0b1111;
System.Console.WriteLine(fileMode);

enum WagonType
{
    Passanger = 0,
    Locomotive = 1,
    CarTransport = 5
}

[Flags] // This is a flag enum
enum FileMode
{
    Read = 0b0001,
    Write = 0b0010,
    CreateIfNotExist = 0b0100,
    DeleteOnClose = 0b1000
}
