namespace BehavioralPattern02.ObserverPattern
{
    public class Stock
    {
        public string Symbol {get; set;}
        public decimal Price {get; private set;}

        public Stock(string symbol, decimal price)
        {
            Symbol = symbol;
            Price = price;
        }

        public void SetPrice(decimal price)
        {
            Price = price;
        }
    }
}