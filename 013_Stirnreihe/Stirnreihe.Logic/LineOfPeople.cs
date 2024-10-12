using System.Diagnostics;
using System.Text;

namespace Stirnreihe.Logic;

// This is the LineOfPeople class
public class LineOfPeople
{
    private Node? First { get; set; } = null;

    public void AddToFront(Person person) // This is the method to add a person to the front of the line
    {
        var node = new Node(person) { Next = First }; // Here we create a new node with the person and the next node is the first node
        First = node;
    }

    public int AddSorted(Person person) // Small -> Big (Smallest at the front)
    {
        int index = 0;
        var node = new Node(person);
        
        if (First == null || person.Height < First.Person.Height) 
        {
            // Here we need to add the node to the front

            node.Next = First;
            First = node;
        }
        else
        {
            var current = First; // We make a current variable and set it to the first node
            while (current!.Next != null && person.Height > current.Next.Person.Height) // While the next node is not null and the person is bigger than the next person
            {
                current = current.Next; // We set the current node to the next node
                index++; // We increment the index
            }

            node.Next = current.Next; // We set the next node of our node to the next node of the current node
            current.Next = node; // Now we need to set the next node of the current node to our node
            index++; // We increment the index
        }

        return index;
    }

    public Person RemovePersonAt(int index)
    {
        Person? person = null; // We make a person variable and set it to null

        if (First == null) { throw new Exception("The line is empty!"); } // If the first node is null, we throw an exception
        else if (index < 0) { throw new Exception("The index must be greater than or equal to 0!"); } // If the index is less than 0, we throw an exception

        if (index == 0) // We need to remove the first node
        {
            person = First.Person;
            First = First.Next;
        }
        else // We need to remove a node that is not the first node
        {
            var previous = First;

            for (int i = 0; i < index - 1; i++) 
            { 
                if (previous.Next == null) { throw new Exception("The index is too big!"); } 
                // If the next node is null, we throw an exception
                previous = previous.Next; 
            }

            if (previous.Next == null) { throw new Exception("The index is too big!"); } 

            person = previous.Next.Person;
            previous.Next = previous.Next.Next;
        }

        return person!;
    }

    public void Sort()
    {
        throw new NotImplementedException("This method is not implemented yet!");
    }

    public void Clear() => First = null; // This is the method to clear the line

    public override string ToString() // This is the override of the ToString method
    {
        var output = new StringBuilder();

        for (var current = First; current != null; current = current.Next)
        {
            output.AppendLine(current.Person.ToString());
        }

        return output.ToString().Trim('\n');
    }
}
