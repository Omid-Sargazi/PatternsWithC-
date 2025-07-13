namespace LeetCode.Patterns.ChainOfResponsibility
{
    public class Transaction
    {
        public string UserName { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public decimal DailyLimit { get; set; }
        public bool IsBlacklisted { get; set; }
    }

    public class TransactionResult
    {
        public List<string> Errors { get; } = new();
        public bool IsSuccess => Errors.Count == 0;
    }

    
}