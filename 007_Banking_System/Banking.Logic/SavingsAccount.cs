namespace Banking.Logic;

public class SavingsAccount : Account
{
    private int OVERDRAFT_LIMIT = 0;
    private int BALANCE_LIMIT = 100_000_000;
    protected override bool IsAllowed(Transaction transaction)
    {
        if (CurrentBalance + transaction.Amount < OVERDRAFT_LIMIT || CurrentBalance + transaction.Amount > BALANCE_LIMIT)
        {
            return false;
        }
        else if (!base.IsAllowed(transaction))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}