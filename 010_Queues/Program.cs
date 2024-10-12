AnimalInQueue? first = null;
AnimalInQueue? last = null;
// Queue is now empty

// Let's add an animal
var a = new AnimalInQueue("Cute Cat");
first = last = a;

// Let's add another animal
a = new AnimalInQueue("Fast horse");
last = a;
first.Next = a;

// Let's add another animal
a = new AnimalInQueue("Axolotl");
last.Next = a;
last = a;

// Let's add another animal
a = new AnimalInQueue("fish");
last.Next = a;
last = a;

// Let's take the first animal out
// So something with cat
first = first.Next; // cat
if (first == null) { last = null; }

class AnimalInQueue(string name)
{
    public string Name { get; } = name;
    public AnimalInQueue? Next { get; set; }
}
