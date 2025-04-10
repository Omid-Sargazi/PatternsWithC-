namespace CompositePattern.ProxyPattern
{
    public class BankAccount
    {
        public int AccountId { get; set; }
    private double _balance = 1000;

    public double GetBalance()
    {
        Console.WriteLine($"Balance for account {AccountId}: {_balance}");
        return _balance;
    }

    public void Withdraw(double amount)
    {
        if (amount <= _balance)
        {
            _balance -= amount;
            Console.WriteLine($"Withdrew {amount}. New balance: {_balance}");
        }
        else
        {
            Console.WriteLine("Insufficient funds!");
        }
    }
    }
}