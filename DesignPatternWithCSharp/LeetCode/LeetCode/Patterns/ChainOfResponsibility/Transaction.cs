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

    public abstract class TransactionHandler
    {
        protected TransactionHandler _next;
        public void SetNext(TransactionHandler next)
        {
            _next = next;
        }

        public void Execute(Transaction transaction, TransactionResult result)
        {
            Console.WriteLine($"[{this.GetType().Name}] is checking...");
            Handle(transaction, result);

            _next?.Execute(transaction, result);

        }

        protected abstract void Handle(Transaction transaction, TransactionResult result);
    }

    public class BalanceCheckHandler : TransactionHandler
    {
        protected override void Handle(Transaction transaction, TransactionResult result)
        {
            if (transaction.Amount > transaction.Balance) result.Errors.Add("the balance is not enough");
        }
    }

    public class DailyLimitHandler : TransactionHandler
    {
        protected override void Handle(Transaction transaction, TransactionResult result)
        {
            if (transaction.Amount > transaction.DailyLimit)
                result.Errors.Add("there is a limition");
        }
    }

    public class BlacklistHandler : TransactionHandler
    {
        protected override void Handle(Transaction transaction, TransactionResult result)
        {
            if (transaction.IsBlacklisted)
                result.Errors.Add("User is block");
        }
    }

    public static class HandlerBuilder
    {
        public static TransactionHandler BuildChain()
        {
            var balance = new BalanceCheckHandler();
            var limit = new DailyLimitHandler();
            var blackList = new BlacklistHandler();

            balance.SetNext(limit);
            limit.SetNext(blackList);
            return balance;
        }
    }
}