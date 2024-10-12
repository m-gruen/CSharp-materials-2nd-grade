IMiceHunter mh = new Owl();

Animal[] zoo = [
    new Cat(),
    new Owl(),
    new Kiwi()
];

IMiceHunter[] hunters = [
    new Cat(),
    new Owl()
];

HuntMice(hunters);

void HuntMice(IEnumerable<IMiceHunter> hunters)
{
    foreach (var hunter in hunters)
    {
        hunter.CatchMouse();
    }

}

abstract class Animal {}

abstract class Bird : Animal 
{
    public virtual bool CanFly => true;
}

interface IMiceHunter
{
    void CatchMouse();
}

class Owl : Bird, IMiceHunter
{
    public void CatchMouse()
    {
        Console.WriteLine("Watch - Fly - Catch");
    }
}

class Kiwi : Bird
{
    public override bool CanFly => false;
}

class Cat : Animal, IMiceHunter
{
    public void CatchMouse()
    {
        Console.WriteLine("Watch - Jump - Catch");
    }

    public void SayMiau() => Console.WriteLine("Miau");
}