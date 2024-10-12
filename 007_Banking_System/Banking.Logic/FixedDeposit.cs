namespace Banking.Logic;

public class FixedDeposit : Account
{
    private int OVERDRAFT_LIMIT = 0;
    private int BALANCE_LIMIT = 100_000_000;

    public DateOnly OpeningDate { get; set; } = DateOnly.MinValue;
    public DateOnly FixedUntil { get; set; } = DateOnly.MinValue;

    protected override bool IsAllowed(Transaction transaction)
    {
        DateOnly TimestampDate = DateOnly.FromDateTime(transaction.Timestamp);

        if (CurrentBalance + transaction.Amount < OVERDRAFT_LIMIT || CurrentBalance + transaction.Amount > BALANCE_LIMIT)
        {
            return false;
        }
        else if (!base.IsAllowed(transaction))
        {
            return false;
        }
        else if (transaction.Amount > 0)
        {  
            if (TimestampDate != OpeningDate)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (transaction.Amount < 0)
        {
            if (TimestampDate < FixedUntil)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }
    }
}