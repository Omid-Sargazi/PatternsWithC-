namespace CompositePattern.ProxyPattern
{
    public class BankAccountGuard
    {
        private BankAccount _bankAccount;
        private string _password;
        public BankAccountGuard(string password)
        {
            _password = password;
        }

        public double GetBalance(string password)
        {
            if(password==_password)
            {
                return _bankAccount.GetBalance();
            }
            else{
                Console.WriteLine("Wrong password!");
                return -1;
            }
        }

        public void Withdraw(double amount, string password)
        {
            if (password == _password)
        {
            _bankAccount.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Wrong password!");
        }
        }


    }
}