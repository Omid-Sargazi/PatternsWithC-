namespace Patterns.BankAccount
{
    public class Transaction
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string RelatedAccountId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}