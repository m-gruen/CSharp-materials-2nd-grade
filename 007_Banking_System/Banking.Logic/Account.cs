namespace Banking.Logic;

public abstract class Account
{
    public string AccountNumber { get; set; } = "";
    public string AccountHolder { get; set; } = "";
    public decimal CurrentBalance { get; set; } = 0.0m;
    public decimal MonthlyInterest { get; set; } = 0.0m;

    protected virtual bool IsAllowed(Transaction transaction)
    {
        return AccountNumber == transaction.AccountNumber;
    }

    public bool TryExecute(Transaction transaction)
    {
        if (IsAllowed(transaction))
        {
            CurrentBalance += transaction.Amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual decimal CalculateMonthlyInterest()
    {
        return CurrentBalance * MonthlyInterest / 12m;
    }
}
