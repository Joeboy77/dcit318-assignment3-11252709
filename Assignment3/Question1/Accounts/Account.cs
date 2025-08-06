using Assignment3.Question1.Models;

namespace Assignment3.Question1.Accounts
{
    public class Account
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; protected set; }

        public Account(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            Console.WriteLine($"Account {AccountNumber} created with initial balance: {Balance:C}");
        }

        public virtual void ApplyTransaction(Transaction transaction)
        {
            Console.WriteLine($"Applying transaction {transaction.Id} to account {AccountNumber}.");
            Balance -= transaction.Amount;
            Console.WriteLine($"New balance for account {AccountNumber}: {Balance:C}");
        }
    }
}