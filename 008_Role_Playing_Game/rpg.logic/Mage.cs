namespace rpg.logic;

public  class Mage : FightingPerson
{
    public AttackItem? AttackItem { get; set; }

    public override double CalculateDamage()
    {
        return AttackItem!.CalculateDamage();
    }
}
