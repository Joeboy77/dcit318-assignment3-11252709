using Assignment3.Question1.Accounts;
using Assignment3.Question1.Interfaces;
using Assignment3.Question1.Models;
using Assignment3.Question1.Processors;

namespace Assignment3.Question1
{
    public class FinanceApp
    {
        private List<Transaction> _transactions;

        public FinanceApp()
        {
            _transactions = new List<Transaction>();
        }

        public void Run()
        {
            SavingsAccount mySavingsAccount = new SavingsAccount("SA-12345", 1000m);
            Console.WriteLine();

            Transaction transaction1 = new Transaction(1, DateTime.Now.AddDays(-2), 150m, "Groceries");
            Transaction transaction2 = new Transaction(2, DateTime.Now.AddDays(-1), 300m, "Utilities");
            Transaction transaction3 = new Transaction(3, DateTime.Now, 700m, "Entertainment");

            ITransactionProcessor mobileMoneyProcessor = new MobileMoneyProcessor();
            ITransactionProcessor bankTransferProcessor = new BankTransferProcessor();
            ITransactionProcessor cryptoWalletProcessor = new CryptoWalletProcessor();
            Console.WriteLine();

            Console.WriteLine("Processing Transactions");
            mobileMoneyProcessor.Process(transaction1);
            bankTransferProcessor.Process(transaction2);
            cryptoWalletProcessor.Process(transaction3);
            Console.WriteLine();

            Console.WriteLine("Applying Transactions to Savings Account");
            mySavingsAccount.ApplyTransaction(transaction1);
            mySavingsAccount.ApplyTransaction(transaction2);
            mySavingsAccount.ApplyTransaction(transaction3);
            Console.WriteLine();

            _transactions.Add(transaction1);
            _transactions.Add(transaction2);
            _transactions.Add(transaction3);

            Console.WriteLine("All Transactions Recorded");
            foreach (var t in _transactions)
            {
                Console.WriteLine($"Transaction ID: {t.Id}, Date: {t.Date.ToShortDateString()}, " +
                                  $"Amount: {t.Amount:C}, Category: {t.Category}");
            }
        }
    }
}