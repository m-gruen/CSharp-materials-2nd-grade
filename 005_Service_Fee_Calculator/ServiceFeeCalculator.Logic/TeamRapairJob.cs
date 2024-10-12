namespace ServiceFeeCalculator.Logic;

public abstract class TeamRepairJob : RepairJob
{
    public int NumberOfMechanics { get; set; }
    public abstract decimal CalculateFeeSingleMechanic { get; }
    
    public override decimal CalculateFee()
    {
        return CalculateFeeSingleMechanic * NumberOfMechanics;
    }
}