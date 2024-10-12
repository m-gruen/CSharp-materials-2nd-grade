namespace ServiceFeeCalculator.Logic;

public class BasicRepairJob : TeamRepairJob
{   
    private const decimal BASIC_FEE = 5m;
    private int StartedQuarterMinutes => (int)Math.Ceiling(TotalHours * 60 / 15);
    public override decimal CalculateFeeSingleMechanic => BASIC_FEE * StartedQuarterMinutes;

    public override string ToString()
    {        
        return $"Basic Repair Job: {CalculateFee()}";
    }
}