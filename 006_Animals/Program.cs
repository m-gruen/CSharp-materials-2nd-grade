using System.IO.Compression;

var cat = new Cat();
cat.MakeSound();
var dog = new Dog();
dog.MakeSound();
Animal animal;
var random = Random.Shared.Next(2);

Animal[] zoo = new Animal[] { new Cat(), new Dog(), new Sheep(), new Bird() };

foreach (var a in zoo)
{
    // Polymorphism
    a.MakeSound();
}

switch (random)
{
    case 0: animal = new Cat(); break;
    case 1: animal = new Dog(); break;
    default: return;
}

// Polymorphism
animal.MakeSound();
Console.WriteLine(animal.Legs);

// animal.Purr(); // Error: Animal does not have a Purr method

// Abstract base class, only for inheritance
abstract class Animal
{
    public abstract int Legs { get; }

    // All descendants must implement this method
    public abstract void MakeSound();

    public override string ToString()
    {
        return "I am in Animal";
    }
    public abstract bool Likes(Animal  other);
}

// Cat is a derived class from Animal
// Animal is the base class of Cat
class Cat : Animal
{
    public override int Legs  => 4;

    // Implement the abstract method
    public override void MakeSound()
    {
        System.Console.WriteLine("Meow");
    }
    public void Purr()
    {
        System.Console.WriteLine("Car Purrrrrrrrrrrrrrrrrrrrs");
    }
    public override string ToString()
    {
        return "I am in Cat";
    }

    public override bool Likes(Animal other)
    {
        // Cats like cats

        return other is Cat;
    }
}

class Dog : Animal
{
    public override int Legs => 4;

    public override void MakeSound()
    {
        System.Console.WriteLine("Woof");
    }

    public override string ToString()
    {
        return "I am in Dog";
    }

    public override bool Likes(Animal other)
    {
        // Dogs like cats and Birds

        return other is Cat or Bird;
    }
}

class Sheep : Animal
{
    public override int Legs => 4;

    public override void MakeSound()
    {
        System.Console.WriteLine("Baaaa");
    }

    public override string ToString()
    {
        return "I am in Sheep";
    }

    public override bool Likes(Animal other) => other is Sheep;

}

class Bird : Animal
{
    public override int Legs => 2;

    public override void MakeSound()
    {
        System.Console.WriteLine("Tweet");
    }

    public override string ToString()
    {
        return "I am in Bird";
    }

    public override bool Likes(Animal other) => other is Bird or Sheep;
}

