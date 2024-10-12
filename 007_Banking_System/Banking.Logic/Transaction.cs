namespace Banking.Logic;

public class Transaction
{
    public string AccountNumber { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime Timestamp { get; set; } = DateTime.Now;

    public decimal Amount { get; set; } = 0.0m;
}