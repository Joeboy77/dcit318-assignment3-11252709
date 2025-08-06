using Assignment3.Question1.Interfaces;
using Assignment3.Question1.Models;

namespace Assignment3.Question1.Processors
{
    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Processing Crypto Wallet: Transaction ID {transaction.Id}, " +
                              $"Amount {transaction.Amount:C}, Category '{transaction.Category}'.");
        }
    }
}