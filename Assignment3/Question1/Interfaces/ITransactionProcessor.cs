using Assignment3.Question1.Models;

namespace Assignment3.Question1.Interfaces
{
    public interface ITransactionProcessor
    {
        void Process(Transaction transaction);
    }
}