namespace rpg.logic;

public class Fight
{
    public void ExecuteFight(FightingPerson attacker, FightingPerson defender)
    {
        double damage = attacker.CalculateDamage();
        double defense = defender.CalculateDefense();

        double damageTaken = damage - defense;

        if (defender is Warrior warrior)
        {
            if (warrior.DefenseItem is not null)
            {
                if (warrior.DefenseItem.BaseValue - damage * 0.3 < 0)
                {
                    warrior.DefenseItem.BaseValue = 0;
                }
                else
                {
                    warrior.DefenseItem.BaseValue -= damage * 0.3;
                }
            }
        }

        if (damageTaken > 0)
        {
            if (defender.Health - damageTaken < 0)
            {
                defender.Health = 0;
            }
            else
            {
                defender.Health -= damageTaken;
            }
        }
    }
}