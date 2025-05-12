namespace BehavioralPattern02.ObserverPattern
{
    public interface IObserverStock
    {
        void Update(string symbol, decimal price);
    }
    public class Stock
    {
        public string Symbol {get; set;}
        public decimal Price {get; private set;}

        private List<IObserverStock> _observer;

        public void AddObserver(IObserverStock observer)
        {
            _observer.Add(observer);
        }

        public void RemoveObserver(IObserverStock observer)
        {
            _observer.Remove(observer);
        }

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

    public class MobileDisplay : IObserverStock
    {
        

        public void Update(string symbol, decimal price)
        {
            Console.WriteLine($"[Mobile] {symbol} updated to {price}");
        }
    }

    public class WebDisplay : IObserverStock
    {
        

        public void Update(string symbol, decimal price)
        {
            Console.WriteLine($"[Web] {symbol} updated to {price}");
        }
    }
}