namespace ServiceFeeCalculator.Logic;

public class ComplexRepairJob : RepairJob
{
    private const decimal COMPLEX_FEE_SUB_4_HOURS = 500m;
    private const decimal COMPLEX_FEE_OVER_4_HOURS = 800m;
    public override decimal CalculateFee()
    {
        if (Successful)
        {
            if (TotalHours <= 4)
            {
                return COMPLEX_FEE_SUB_4_HOURS;
            }
            else
            {
                return COMPLEX_FEE_OVER_4_HOURS;
            }
        }
        return 0m;
    }

    public override string ToString()
    {
        return $"Complex Repair Job: {CalculateFee()}";
    }
}