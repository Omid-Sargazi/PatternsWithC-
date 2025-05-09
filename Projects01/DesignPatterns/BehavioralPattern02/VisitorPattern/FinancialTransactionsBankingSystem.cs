namespace BehavioralPattern02.VisitorPattern
{
    public interface IBankingVisitor
    {
        void Visit(Deposit deposit);
        void Visit(Withdrawal withdrawal);
        void Visit(Transfer transfer);
    }

    public interface IBankingTransition
    {
        void Accept(IBankingVisitor visitor);
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }

    public class Deposit : IBankingTransition
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string AccountId {get; set;}
        public Deposit(decimal amount, string accountId)
        {
            Amount = amount;
            Date = DateTime.Now;
            AccountId = accountId;
        }

        public void Accept(IBankingVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Withdrawal : IBankingTransition
    {
        public decimal Amount { get; set;}
        public DateTime Date { get; set; }
        public string AccountId { get; set; }
        public string ReferenceNumber { get; set; }
        public Withdrawal(decimal amount, string accountId, string referenceNumber)
        {
            Amount = amount;
            Date = DateTime.Now;
            AccountId = accountId;
            ReferenceNumber = referenceNumber;
        }

        public void Accept(IBankingVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Transfer : IBankingTransition
    {
        public decimal Amount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SourceAccountId { get; set; }
        public string DestinationAccountId { get; set; }
        public Transfer(decimal amount, string sourceAccountId, string destinationAccountId)
        {
            Amount = amount;
            SourceAccountId = sourceAccountId;
            DestinationAccountId = destinationAccountId;
            Date = DateTime.Now;
        }

        public void Accept(IBankingVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}