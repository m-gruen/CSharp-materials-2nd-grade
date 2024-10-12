using Banking.Logic;

Console.OutputEncoding = System.Text.Encoding.Default;

System.Console.Write("Type of account ([c]hecking, [b]usiness, [s]avings, [f]ixed Deposit): ");
var accountType = System.Console.ReadLine()!.ToLower();
System.Console.Write("Account number: ");
var accountNumber = System.Console.ReadLine()!;
System.Console.Write("Account holder: ");
var accountHolder = System.Console.ReadLine()!;
System.Console.Write("Current balance: ");
var currentBalance = decimal.Parse(System.Console.ReadLine()!);

DateOnly openingDate = DateOnly.MinValue;
DateOnly fixedUntil = DateOnly.MinValue;
if (accountType == "f")
{
    System.Console.Write("Opening date: ");
    openingDate = DateOnly.Parse(System.Console.ReadLine()!);
    System.Console.Write("Fixed until date: ");
    fixedUntil = DateOnly.Parse(System.Console.ReadLine()!);
}

System.Console.Write("Transaction account number: ");
var transactionAccountNumber = System.Console.ReadLine()!;
System.Console.Write("Transaction description: ");
var transactionDescription = System.Console.ReadLine()!;
System.Console.Write("Transaction amount: ");
var transactionAmount = decimal.Parse(System.Console.ReadLine()!);
System.Console.Write("Transaction timestamp: ");
var transactionTimestamp = DateTime.Parse(System.Console.ReadLine()!);

Account account = accountType switch
{
    "c" => new CheckingAccount(),
    "b" => new BusinessAccount(),
    "s" => new SavingsAccount(),
    "f" => new FixedDeposit(),
    _ => throw new Exception("Invalid account type.")
};

account.AccountNumber = accountNumber;
account.AccountHolder = accountHolder;
account.CurrentBalance = currentBalance;

if (accountType == "f")
{
    ((FixedDeposit)account).OpeningDate = openingDate; // cast to FixedDeposit
    ((FixedDeposit)account).FixedUntil = fixedUntil;
}

var transaction = new Transaction
{
    AccountNumber = transactionAccountNumber,
    Description = transactionDescription,
    Amount = transactionAmount,
    Timestamp = transactionTimestamp
};

if (account.TryExecute(transaction))
{
    System.Console.WriteLine($"Transaction executed successfully. The new current balance is {account.CurrentBalance}€.");
}
else
{
    System.Console.WriteLine("Transaction not allowed.");
}