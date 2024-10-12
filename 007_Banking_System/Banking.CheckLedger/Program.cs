using Banking.Logic;

var accountDataFile = args[0];
var transactionDataFile = args[1];

var workingDirectory = Directory.GetCurrentDirectory();

var accountData = File.ReadAllLines($@"{workingDirectory}\{accountDataFile}").Skip(1).ToArray();
var transactionData = File.ReadAllLines($@"{workingDirectory}\{transactionDataFile}").Skip(1).ToArray();

Account[] accounts = new Account[accountData.Length];
Transaction[] transactions = new Transaction[transactionData.Length];

for(int i = 0; i < accountData.Length; i++)
{
    var lines = accountData[i].Split(';');
    var accountType = lines[0];
    var accountNumber = lines[1];
    var accountHolder = lines[2];
    var currentBalance = decimal.Parse(lines[3]);

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
        var openingDate = DateOnly.Parse(lines[4]);
        var fixedUntil = DateOnly.Parse(lines[5]);
        
        ((FixedDeposit)account).OpeningDate = openingDate; // cast to FixedDeposit
        ((FixedDeposit)account).FixedUntil = fixedUntil;
    }

    accounts[i] = account;
}

for (int i = 0; i < transactionData.Length; i++)
{
    var lines = transactionData[i].Split(';');
    var transactionAccountNumber = lines[0];
    var transactionDescription = lines[1];
    var transactionAmount = decimal.Parse(lines[2]);
    var transactionTimestamp = DateTime.Parse(lines[3]);

    var transaction = new Transaction
    {
        AccountNumber = transactionAccountNumber,
        Description = transactionDescription,
        Amount = transactionAmount,
        Timestamp = transactionTimestamp
    };

    transactions[i] = transaction;
}

foreach (var transaction in transactions)
{
    foreach (var account in accounts)
    {
        if (account.AccountNumber == transaction.AccountNumber)
        {
            if (account.TryExecute(transaction)) { }
            else
            {
                System.Console.WriteLine($"Transaction with description {transaction.Description} on {transaction.Timestamp} not allowed.");
            }
        }
    }
}