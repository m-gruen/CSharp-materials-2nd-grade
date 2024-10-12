using rpg.logic;

var weapons = new AttackItem[]
{
    new Weapon { Name = "Fist", BaseValue = 4},
    new Weapon { Name = "Stick", BaseValue = 5},
    new Weapon { Name = "Rock", BaseValue = 7},
    new Weapon { Name = "Shovel", BaseValue = 8},
    new Weapon { Name = "Wood Sword", BaseValue = 9},
    new Weapon { Name = "Cooking Knife", BaseValue = 9},
    new Weapon { Name = "Dagger", BaseValue = 10},
    new Weapon { Name = "Knife", BaseValue = 11},
    new Weapon { Name = "Spear", BaseValue = 12},
    new Weapon { Name = "Stone Sword", BaseValue = 12},
    new Weapon { Name = "Sling", BaseValue = 13},
    new Weapon { Name = "Bow", BaseValue = 13},
    new Weapon { Name = "Hammer", BaseValue = 14},
    new Weapon { Name = "Staff", BaseValue = 15},
    new Weapon { Name = "Stabbing Knife", BaseValue = 15},
    new Weapon { Name = "Iron Sword", BaseValue = 16},
    new Weapon { Name = "Crossbow", BaseValue = 16},
    new Weapon { Name = "Axe", BaseValue = 17},
    new Weapon { Name = "Diamond Sword", BaseValue = 18},
    new Weapon { Name = "Op-Fist", BaseValue = 22},
    new Weapon { Name = "Thunder Blade", BaseValue = 30},
    new Weapon { Name = "Excalibur", BaseValue = 40},
    new Weapon { Name = "Mjolnir", BaseValue = 50}
};

var attackSpells = new AttackItem[]
{
    new AttackSpell { Name = "Air", BaseValue = 3},
    new AttackSpell { Name = "Water", BaseValue = 4},
    new AttackSpell { Name = "Wind", BaseValue = 5},
    new AttackSpell { Name = "Fireball", BaseValue = 10},
    new AttackSpell { Name = "Ice Shard", BaseValue = 10},
    new AttackSpell { Name = "Lightning Bolt", BaseValue = 10},
    new AttackSpell { Name = "Tornado", BaseValue = 11},
    new AttackSpell { Name = "Earthquake", BaseValue = 12},
    new AttackSpell { Name = "Thunderstorm", BaseValue = 13},
    new AttackSpell { Name = "Poison", BaseValue = 14},
    new AttackSpell { Name = "Blizzard", BaseValue = 14},
    new AttackSpell { Name = "Acid", BaseValue = 15},
    new AttackSpell { Name = "Firestorm", BaseValue = 16},
    new AttackSpell { Name = "Tsunami", BaseValue = 16},
    new AttackSpell { Name = "Acid Rain", BaseValue = 17},
    new AttackSpell { Name = "Meteor", BaseValue = 18},
    new AttackSpell { Name = "Thunderstorm", BaseValue = 19},
    new AttackSpell { Name = "Radiation", BaseValue = 20},
    new AttackSpell { Name = "Supernova", BaseValue = 22},
    new AttackSpell { Name = "Black Hole", BaseValue = 30},
    new AttackSpell { Name = "Radioactive Supernova", BaseValue = 40},
    new AttackSpell { Name = "Big Bang", BaseValue = 50}
};

var shields = new DefenseItem[]
{
    new Shield { Name = "Wooden Shield", BaseValue = 5},
    new Shield { Name = "Stone Shield", BaseValue = 7},
    new Shield { Name = "Iron Shield", BaseValue = 10},
    new Shield { Name = "Diamond Shield", BaseValue = 15},
    new Shield { Name = "Op-Shield", BaseValue = 20},
    new Shield { Name = "Thunder Shield", BaseValue = 25},
    new Shield { Name = "Black Hole Shield", BaseValue = 30},
    new Shield { Name = "Kryptonite Shield", BaseValue = 35}
};

var Armors = new DefenseItem[]
{
    new Armor { Name = "Leather Armor", BaseValue = 5},
    new Armor { Name = "Chains Armor", BaseValue = 7},
    new Armor { Name = "Iron Armor", BaseValue = 10},
    new Armor { Name = "Diamond Armor", BaseValue = 15},
    new Armor { Name = "Op-Armor", BaseValue = 20},
    new Armor { Name = "Blast-Proof Armor", BaseValue = 22},
    new Armor { Name = "Thunder Armor", BaseValue = 25},
    new Armor { Name = "Black Hole Armor", BaseValue = 30},
    new Armor { Name = "Kryptonite Armor", BaseValue = 35}
};


var fightingPersons = new FightingPerson[500];

int WarriorCount = 1;
int MageCount = 1;
int RogueCount = 1;

for (int i = 0; i < fightingPersons.Length; i++)
{
    int randomPerson = Random.Shared.Next(0, 3);

    int weaponOrSpell = Random.Shared.Next(0, 2);
    int shieldOrArmor = Random.Shared.Next(0, 2);

    int randomWeapon = Random.Shared.Next(0, weapons.Length);
    int randomShield = Random.Shared.Next(0, shields.Length);
    int randomArmor = Random.Shared.Next(0, Armors.Length);
    int randomAttackSpell = Random.Shared.Next(0, attackSpells.Length);

    int randomHealth = GenerateRandomHealth();

    if (randomPerson == 0)
    {
        fightingPersons[i] = new Warrior()
        {
            Name = $"Warrior {WarriorCount}",
            AttackItem = weaponOrSpell == 0 ? weapons[randomWeapon] : attackSpells[randomAttackSpell],
            DefenseItem = shieldOrArmor == 0 ? shields[randomShield] : Armors[randomArmor],
            Health = randomHealth
        };
        WarriorCount++;
    }
    else if (randomPerson == 1)
    {
        fightingPersons[i] = new Mage()
        {
            Name = $"Mage {MageCount}",
            AttackItem = weaponOrSpell == 0 ? weapons[randomWeapon] : attackSpells[randomAttackSpell],
            Health = randomHealth
        };
        MageCount++;
    }
    else
    {
        fightingPersons[i] = new Rogue()
        {
            Name = $"Rogue {RogueCount}",
            AttackItem1 = weapons[randomWeapon],
            AttackItem2 = attackSpells[randomAttackSpell],
            Health = randomHealth
        };
        RogueCount++;
    }
}


var fight = new Fight();

var fightingPerson1 = fightingPersons[Random.Shared.Next(0, fightingPersons.Length)];
var fightingPerson2 = fightingPersons[Random.Shared.Next(0, fightingPersons.Length)];

var counter = Random.Shared.Next(0, 2);

Console.WriteLine($"{fightingPerson1} vs {fightingPerson2}");
System.Console.WriteLine();

System.Console.Write("Press 'I' to see further Information of the fighting persons... ");
var input = Console.ReadLine()!;

if (input.ToLower() == "i")
{
    System.Console.WriteLine("Information:");
    System.Console.WriteLine();
    System.Console.WriteLine($"{fightingPerson1}: ");
    PrintInfo(fightingPerson1);
    System.Console.WriteLine();
    System.Console.WriteLine($"{fightingPerson2}: ");
    PrintInfo(fightingPerson2);
    System.Console.WriteLine();
    System.Console.WriteLine("Press any key to start the fight...");
    Console.ReadLine();
}



while (fightingPerson1.Health > 0 && fightingPerson2.Health > 0)
{
    if (counter % 2 == 0)
    {
        fight.ExecuteFight(fightingPerson1, fightingPerson2);
    }
    else
    {
        fight.ExecuteFight(fightingPerson2, fightingPerson1);
    }

    System.Console.WriteLine($"{fightingPerson1} has {Math.Round(fightingPerson1.Health, 2)} health left");
    System.Console.WriteLine($"{fightingPerson2} has {Math.Round(fightingPerson2.Health, 2)} health left");
    System.Console.WriteLine();

    counter++;
}

if (fightingPerson1.Health > 0)
{
    System.Console.WriteLine($"{fightingPerson1} won!");
    System.Console.WriteLine($"Health left: {Math.Round(fightingPerson1.Health, 2)}");
}
else
{
    System.Console.WriteLine($"{fightingPerson2} won!");
    System.Console.WriteLine($"Health left: {Math.Round(fightingPerson2.Health, 2)}");
}



int GenerateRandomHealth()
{
    // Making the higher healths more rare
    
    var healths = new int[100];

    for (int i = 0; i < 70; i++)
    {
        healths[i] = Random.Shared.Next(100, 151);
    }

    for (int i = 70; i < 90; i++)
    {
        healths[i] = Random.Shared.Next(100, 201);
    }

    for (int i = 90; i < 98; i++)
    {
        healths[i] = Random.Shared.Next(100, 401);
    }

    for (int i = 98; i < 100; i++)
    {
        healths[i] = Random.Shared.Next(100, 801);
    }

    return healths[Random.Shared.Next(0, 100)];
}

void PrintInfo(FightingPerson fightingPerson)
{
    System.Console.WriteLine($"Health: {fightingPerson.Health}");
    if (fightingPerson is Rogue)
    {
        var rogue = (Rogue)fightingPerson;
        System.Console.WriteLine($"Attack Item 1: {rogue.AttackItem1}");
        System.Console.WriteLine($"Attack Item 2: {rogue.AttackItem2}");
    }
    else if (fightingPerson is Mage)
    {
        var mage = (Mage)fightingPerson;
        System.Console.WriteLine($"Attack Item: {mage.AttackItem}");
    }
    else if (fightingPerson is Warrior)
    {
        var warrior = (Warrior)fightingPerson;
        System.Console.WriteLine($"Attack Item: {warrior.AttackItem}");
        System.Console.WriteLine($"Defense Item: {warrior.DefenseItem}");
    }

}