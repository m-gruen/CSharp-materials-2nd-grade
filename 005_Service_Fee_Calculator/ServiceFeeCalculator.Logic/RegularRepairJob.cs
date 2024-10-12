namespace ServiceFeeCalculator.Logic;

public class RegularRepairJob : TeamRepairJob
{
    private const decimal REGULAR_FEE = 80m;
    public override decimal CalculateFeeSingleMechanic => REGULAR_FEE * StartedHours;

    public override string ToString()
    {
        return $"Regular Repair Job: {CalculateFee()}";
    }
}