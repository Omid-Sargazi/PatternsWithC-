namespace Patterns.BankAccount
{
    public interface IFraudDetectionService
{
    Task<bool> CheckDeposit(string accountId, decimal amount, string source);
    Task<bool> CheckWithdrawal(string accountId, decimal amount, string destination);
    Task<bool> CheckTransfer(string fromAccountId, string toAccountId, decimal amount);
}
}