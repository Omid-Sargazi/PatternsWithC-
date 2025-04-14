namespace Patterns.BankAccount
{
    public interface IAccountService
{
    Task<bool> AddFunds(string accountId, decimal amount);
    Task<bool> DeductFunds(string accountId, decimal amount);
    Task<bool> CheckBalance(string accountId, decimal amount);
}
}