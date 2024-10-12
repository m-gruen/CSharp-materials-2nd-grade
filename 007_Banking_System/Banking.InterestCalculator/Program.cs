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

System.Console.Write("Interest rate: ");
var interestRate = decimal.Parse(System.Console.ReadLine()!);

var borrowingRate = 0.0m;
if (accountType is "c" or "b")
{
    System.Console.Write("Borrowing rate: ");
    borrowingRate = decimal.Parse(System.Console.ReadLine()!);
}

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
account.MonthlyInterest = interestRate;

if (accountType is "c" or "b")
{
    ((BorrowingAccount)account).BorrowingRate = borrowingRate; // cast to BorrowingAccount
}

System.Console.WriteLine($"The monthly interest is {Math.Round(account.CalculateMonthlyInterest(), 2)}€.");
