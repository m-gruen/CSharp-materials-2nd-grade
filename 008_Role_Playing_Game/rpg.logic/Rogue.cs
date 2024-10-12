namespace rpg.logic;

public  class Rogue : FightingPerson
{
    public AttackItem? AttackItem1 { get; set; }
    public AttackItem? AttackItem2 { get; set; }

    public override double CalculateDamage()
    {
        return AttackItem1!.CalculateDamage() + AttackItem2!.CalculateDamage();
    }
}
