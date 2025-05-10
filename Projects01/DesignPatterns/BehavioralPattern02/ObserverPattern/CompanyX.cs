namespace BehavioralPattern02.ObserverPattern
{
    public class CompanyX
    {
        private double _stockPrice;
        private List<Investor> _investors;
        public CompanyX(Investor investor)
        {
            _stockPrice = 100.0;
            _investors = new List<Investor>();

        }

        public void AddInvestor(Investor investor)
        {
            _investors.Add(investor);
        }

        public void SetStockPrice(double price)
        {
            _stockPrice = price;
            foreach(var investor in _investors)
            {
                investor.Update(price);
            }
        }
    }


    public class Investor
    {
        private string name;

        public Investor(string name)
        {
            this.name = name;
        }

        public void Update(double stockPrice)
        {
            Console.WriteLine($"{name} received update: CompanyX stock price is now {stockPrice}");
        }
    }
}