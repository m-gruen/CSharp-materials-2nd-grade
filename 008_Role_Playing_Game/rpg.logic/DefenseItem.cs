namespace rpg.logic;

public abstract class DefenseItem : Item
{
    public abstract double CalculateDefense();

    public override string ToString()
    {
        return $"{Name} (Defense: {BaseValue})";
    }
}

public class Shield : DefenseItem
{
    // Always works
    private int MaxDefense = 100;
    private int MinDefense = 75;
    public override double CalculateDefense()
    {
        double randomDefense = Random.Shared.Next(MinDefense, MaxDefense + 1);

        return BaseValue * randomDefense / 100;
    }
}

public class Armor : DefenseItem
{
    private int WorkingPercentage = 90;
    // Alway defense 100% 
    public override double CalculateDefense()
    {
        if (Random.Shared.Next(0, 101) <= WorkingPercentage)
        {
            return BaseValue;
        }
        return 0;
    }
}