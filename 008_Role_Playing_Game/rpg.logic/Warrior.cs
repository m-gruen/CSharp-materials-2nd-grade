namespace rpg.logic;

public  class Warrior : FightingPerson
{
    public DefenseItem? DefenseItem { get; set; } 
    public AttackItem? AttackItem { get; set; }

    public override double CalculateDamage()
    {
        return AttackItem!.CalculateDamage();
    }

    public override double CalculateDefense()
    {
        return DefenseItem!.CalculateDefense();
    }
}
