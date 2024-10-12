namespace Stirnreihe.Logic;

// This is the Person class
public class Person (string firstName, string lastName, int height)
{
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public int Height { get; set; } = height;
    public override string ToString() => $"{LastName}, {FirstName} ({Height} cm)"; // This is the override of the ToString method
}
