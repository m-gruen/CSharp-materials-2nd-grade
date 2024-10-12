namespace Banking.Logic;

public class BusinessAccount : BorrowingAccount
{
    private int TRANSACTION_LIMIT = 100_000;
    private int OVERDRAFT_LIMIT = -1_000_000;
    private int BALANCE_LIMIT = 100_000_000;


    protected override bool IsAllowed(Transaction transaction)
    {
        if (Math.Abs(transaction.Amount) > TRANSACTION_LIMIT)
        {
            return false;
        }
        else if (CurrentBalance + transaction.Amount < OVERDRAFT_LIMIT || CurrentBalance + transaction.Amount > BALANCE_LIMIT)
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