namespace Patterns.BankAccount
{
    public interface ITransactionRepository
    {
        Task SaveTransaction(Transaction transaction);
    }
}