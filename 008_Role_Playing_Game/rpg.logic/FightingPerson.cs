namespace rpg.logic;

public abstract class FightingPerson
{
    public string Name { get; set; } = "No-name person";
    public double Health { get; set; } = 100;

    public virtual double CalculateDamage()
    {
        return 0;
    }

    public virtual double CalculateDefense()
    {
       return 0;
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}
