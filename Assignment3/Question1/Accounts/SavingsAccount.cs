using Assignment3.Question1.Models;

namespace Assignment3.Question1.Accounts
{
    public sealed class SavingsAccount : Account
    {
        public SavingsAccount(string accountNumber, decimal initialBalance)
            : base(accountNumber, initialBalance)
        {
            Console.WriteLine($"Savings Account {AccountNumber} initialized.");
        }

        public override void ApplyTransaction(Transaction transaction)
        {
            Console.WriteLine($"Applying transaction {transaction.Id} to Savings Account {AccountNumber}.");
            if (transaction.Amount > Balance)
            {
                Console.WriteLine($"Insufficient funds in Savings Account {AccountNumber} for transaction {transaction.Id}. " +
                                  $"Attempted deduction: {transaction.Amount:C}, Current Balance: {Balance:C}.");
            }
            else
            {
                base.ApplyTransaction(transaction);
            }
        }
    }
}