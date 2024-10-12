using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace RestaurantQueue.Logic;

public class CustomerInQueue(string name, string phoneNumber)
{
    public string Name { get; set; } = name;
    public string PhoneNumber { get; set; } = phoneNumber;
    public CustomerInQueue? Next { get; set; }
}

public class RestaurantQueue
{
    private CustomerInQueue? First { get; set; }
    private CustomerInQueue? Last { get; set; }

    public void Add(string name, string phoneNumber)
    {
        var customer = new CustomerInQueue(name, phoneNumber);

        if (First == null)
        {
            First = customer;
            Last = customer;
        }
        else
        {
            Debug.Assert(Last != null, "If first is not null, last must not be null");
            Last.Next = customer;
            Last = customer;
        }
    }

    public string Seat()
    {
        string output = "";
        if (First == null) { output = "The queue is empty"; }
        else
        {
            output = $"Seating {First!.Name} ({First!.PhoneNumber})";
            First = First!.Next;
            if (First == null) { Last = null; }
        }
        return output;
    }

    public string Display()
    {
        StringBuilder output = new();
        if (First == null)
        {
            output.AppendLine("The queue is empty");
        }
        else
        {
            var current = First;
            while (current != null)
            {
                output.AppendLine($"{current.Name} ({current.PhoneNumber})");
                current = current.Next;
            }
        }

        return output.ToString().TrimEnd('\r', '\n');
    }

    public string Save(string path)
    {
        StringBuilder output = new();

        var current = First;
        while (current != null)
        {
            output.AppendLine($"{current.Name};{current.PhoneNumber}");
            current = current.Next;
        }
        File.WriteAllText(path, output.ToString());

        return $"Saved {QueueLength()} customers to queue.csv";
    }

    public string Load(string path)
    {
        string[] lines = File.ReadAllLines(path);

        First = Last = null;

        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            Add(parts[0], parts[1]);
        }

        return $"Loaded {QueueLength()} customers from queue.csv";
    }

    public string Remove(string name)
    {
        if (First == null) { return "The queue is empty"; }
        else
        {
            if (First.Name == name)
            {
                _ = Seat();
            }
            else
            {
                var current = First;
                while (current.Next != null)
                {
                    if (current.Next.Name == name)
                    {
                        current.Next = current.Next.Next;
                        if (current.Next == null) { Last = current; }
                        break;
                    }
                    current = current.Next;
                }
            }
            return $"Removed {name} from the queue";
        }
    }

    private int QueueLength()
    {
        int length = 0;
        for (var current = First; current != null; current = current.Next) { length++; }
        return length;
    }
}
