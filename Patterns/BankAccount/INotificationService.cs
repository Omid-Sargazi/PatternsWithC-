namespace Patterns.BankAccount
{
    public interface INotificationService
{
    Task SendDepositConfirmation(string accountId, decimal amount);
    Task SendWithdrawalConfirmation(string accountId, decimal amount);
    Task SendTransferConfirmation(string fromAccountId, string toAccountId, decimal amount);
    Task SendFraudAlert(string accountId, decimal amount, string transactionType);
    Task SendInsufficientFundsNotification(string accountId, decimal amount);
}
}