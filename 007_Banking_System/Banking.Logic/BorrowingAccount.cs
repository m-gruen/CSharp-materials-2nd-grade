namespace Banking.Logic;

public abstract class BorrowingAccount : Account
{
    public decimal BorrowingRate { get; set; }
    
    public override decimal CalculateMonthlyInterest()
    {
        if (CurrentBalance < 0)
        {
            return CurrentBalance * BorrowingRate / 12m;
        }
        else
        {
            return base.CalculateMonthlyInterest();
        }
    }
}