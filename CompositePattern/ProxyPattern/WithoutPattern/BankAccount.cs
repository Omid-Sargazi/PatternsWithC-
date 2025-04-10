namespace CompositePattern.ProxyPattern.WithoutPattern
{
    public class BankAccount
    {
        public int AccountId {get; set;}
        private double _balance = 1000;
        private string _password = "secret"; 

        public double GetBalance(string password)
    {   
        if(_password == password)
        {
        Console.WriteLine($"Balance for account {AccountId}: {_balance}");
        return _balance;
        }
        else{
            Console.WriteLine("Wrong password!");
            return -1;
        }
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