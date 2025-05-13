using BehavioralPattern02.ObserverPattern;
using BehavioralPattern02.PrototypePattern;

public class Program
{
    public static void Main(string[] args)
    {
        var stock = new Stock("MSFT",300.00m);
        // Console.WriteLine($"Stock: {stock.Symbol}, Price: {stock.Price}");
        // stock.SetPrice(305.05m);
        // Console.WriteLine($"Stock: {stock.Symbol}, Price: {stock.Price}");

        // var station = new WeatherStation();
        // station.SetMeasurements(25.5f,60.6f);
        // Console.WriteLine($"temp {station.Temperature} Humidity:{station.Humidity}");

        var warrior = new GameCharacter
        {
            Name = "Warrior1",
            Health = 150,
            Mana = 20,
            Strength = 80,
        };

        warrior.Display();

        var warrior02 = new GameCharacter
        {
            Name = "Warrior2",
            Health = 150,
            Mana = 20,
            Strength = 80,
        };
        warrior02.Display();

       
    }
}