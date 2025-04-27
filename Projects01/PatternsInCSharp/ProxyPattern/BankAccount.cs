using System.Security.Cryptography;

namespace PatternsInCSharp.ProxyPattern;
public interface IBankAccount
{
    void Withdraw(decimal amount);
}

public class RealBankAccount : IBankAccount
{
    private decimal _balance;

    public RealBankAccount(decimal initialBalance)
    {
        _balance = initialBalance;
    }
    public void Withdraw(decimal amount)
    {
        if(amount <= _balance)
        {
            _balance -= amount;
            Console.WriteLine($"Withdrawal successful. New balance: {_balance}");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }
}


public class BankAccountProxy : IBankAccount
{
    private readonly RealBankAccount _realBankAccount;
    private decimal _balance;
    private bool _isAuthenticated;
    public BankAccountProxy(RealBankAccount realBankAccount)
    {
        _realBankAccount = realBankAccount;
    }
    public void Withdraw(decimal amount)
    {
        if(_isAuthenticated)
        {
            _realBankAccount.Withdraw(amount);
        }else
        {
            Console.WriteLine("Authentication required to withdraw funds.");
        }
    }

    public void Authenticate(string password)
    {
        if(password == "123")
        {
            _isAuthenticated = true;
            Console.WriteLine("Authentication successful.");
        }else
        {
            Console.WriteLine("Authentication failed.");
        }
    }
}
