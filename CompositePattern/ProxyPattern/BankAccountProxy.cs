namespace CompositePattern.ProxyPattern
{
    public class BankAccountProxy : IBankAccount
    {
        private RealBankAccount _realBankAccount;
        private string _password = "secret";
        private int _accountId; 
        public double GetBalance()
        {
            if(!CheckAccess(_password)) return -1;
            if(_realBankAccount == null)
            {
                _realBankAccount = new RealBankAccount {AccountId = _accountId};
            }
                return _realBankAccount.GetBalance();
        }


        public void Withdraw(double amount)
        {
           if(!CheckAccess("secret")) return;
           if(_realBankAccount == null) _realBankAccount = new RealBankAccount {AccountId = _accountId};
           _realBankAccount.Withdraw(amount);
        }

        private bool CheckAccess(string password)
        {
            if(password == _password) return true;
            Console.WriteLine("Wrong password!");
            return false;
        }
    }
}