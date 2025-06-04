namespace AdventureWorksConsole.ObserverPattern;

public interface IObserverStock
{
    void Update(string stockSymbol, decimal price);
}

public interface ISubjectStock
{
    void RegisterObserver(IObserverStock observer);
    void RemoveObserver(IObserverStock observer);
    void NotifyObservers();
}

public class StockMarket : ISubjectStock
{
    private List<IObserverStock> _observers = new List<IObserverStock>();
    private decimal _price;
    private string _stockSymbol;
    public StockMarket(string stockSymbol)
    {
        _stockSymbol = stockSymbol;
    }
    public void SetPrice(decimal price)
    {
        _price = price;
        NotifyObservers();
    }
    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_stockSymbol, _price);
        }
    }

    public void RegisterObserver(IObserverStock observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserverStock observer)
    {
        _observers.Remove(observer);
    }
}


public class TradingApp : IObserver
{
    public void Update(float temp)
    {
        throw new NotImplementedException();
    }
}

public class WebDashboard : IObserverStock
{
    public void Update(string stockSymbol, decimal price)
    {
        Console.WriteLine($"داشبورد وب: قیمت {stockSymbol} به {price:C} رسید.");
    }
}
