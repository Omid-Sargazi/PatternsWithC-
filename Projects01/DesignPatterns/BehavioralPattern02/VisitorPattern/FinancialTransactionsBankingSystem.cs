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

    public class TransactionProcessorVisitor : IBankingVisitor
    {
        public void Visit(Deposit deposit)
        {
            Console.WriteLine($"Processing deposit of {deposit.Amount:C} to account {deposit.AccountId}");
            UpdateAccountBalance(deposit.AccountId, deposit.Amount);
            LogTransaction("Deposit", deposit.Amount, deposit.Date);
        }

        public void Visit(Withdrawal withdrawal)
        {
            Console.WriteLine($"Processing withdrawal of {withdrawal.Amount:C} from account {withdrawal.AccountId} with reference {withdrawal.ReferenceNumber}");
                // Update account balance
                UpdateAccountBalance(withdrawal.AccountId, -withdrawal.Amount);
                // Log transaction
                LogTransaction("Withdrawal", withdrawal.Amount, withdrawal.Date);
        }

        public void Visit(Transfer transfer)
        {
            Console.WriteLine($"Processing transfer of {transfer.Amount:C} from account {transfer.SourceAccountId} to account {transfer.DestinationAccountId}");
                // Update source account
                UpdateAccountBalance(transfer.SourceAccountId, -transfer.Amount);
                // Update destination account
                UpdateAccountBalance(transfer.DestinationAccountId, transfer.Amount);
                // Log transaction
                LogTransaction("Transfer", transfer.Amount, transfer.Date);
        }

        private void UpdateAccountBalance(string accountId, decimal amount)
        {
             Console.WriteLine($"Updated account {accountId} balance by {amount:C}");
        }

        private void LogTransaction(string type, decimal amount, DateTime date)
        {
            Console.WriteLine($"Logged {type} of {amount:C} on {date}");
        }
    }

    public class GenerateReportVisitor : IBankingVisitor
    {
        decimal totalDeposits = 0;
        decimal totalWithdrawals = 0;
        decimal totalTransfers = 0;
        public void Visit(Deposit deposit)
        {
            totalDeposits += deposit.Amount;
            Console.WriteLine($"Total Deposits: {totalDeposits:C}");
        }

        public void Visit(Withdrawal withdrawal)
        {
            totalWithdrawals += withdrawal.Amount;
             Console.WriteLine($"Total Withdrawals: {totalWithdrawals:C}");
        }

        public void Visit(Transfer transfer)
        {
            totalTransfers += transfer.Amount;
            Console.WriteLine($"Total Transfers: {totalTransfers:C}");
        }
    }
}