namespace rpg.logic;

public abstract class AttackItem : Item
{
    public abstract double CalculateDamage();

    public override string ToString()
    {
        return $"{Name} (Damage: {BaseValue})";
    }
}

public class AttackSpell : AttackItem
{   
    private int WorkingPercentage = 80;
    // Alway does 100% damage

    public override double CalculateDamage()
    {
        if (Random.Shared.Next(0, 101) <= WorkingPercentage)
        {
            return BaseValue;
        }
        return 0;
    }
}

public class Weapon : AttackItem
{
    // Always works
    private int MaxDamage = 100;
    private int MinDamage = 50;

    public override double CalculateDamage()
    {
        double randomDamage = Random.Shared.Next(MinDamage, MaxDamage + 1);

        return BaseValue * randomDamage / 100;
    }
}