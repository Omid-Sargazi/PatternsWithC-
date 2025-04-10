namespace CompositePattern.ProxyPattern
{
    public interface IBankAccount
    {
        double GetBalance();
        void Withdraw(double amount);
    }
}