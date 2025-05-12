using BehavioralPattern02.ObserverPattern;

public class Program
{
    public static void Main(string[] args)
    {
        var stock = new Stock("MSFT",300.00m);
        // Console.WriteLine($"Stock: {stock.Symbol}, Price: {stock.Price}");
        // stock.SetPrice(305.05m);
        // Console.WriteLine($"Stock: {stock.Symbol}, Price: {stock.Price}");

        var station = new WeatherStation();
        station.SetMeasurements(25.5f,60.6f);
        Console.WriteLine($"temp {station.Temperature} Humidity:{station.Humidity}");

       
    }
}