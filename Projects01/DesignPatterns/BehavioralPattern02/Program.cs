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

        // var warrior = new GameCharacter
        // {
        //     Name = "Warrior1",
        //     Health = 150,
        //     Mana = 20,
        //     Strength = 80,
        // };

        // warrior.Display();

        // var warrior02 = new GameCharacter
        // {
        //     Name = "Warrior2",
        //     Health = 150,
        //     Mana = 20,
        //     Strength = 80,
        // };
        // warrior02.Display();

        // var mageTemplate = new GameCharacter
        // {
        //     Name = "MageTemplate",
        //     Health = 80,
        //     Mana = 150,
        //     Strength = 30
        // };
        
        // var mage1 = new GameCharacter(mageTemplate);
        // mage1.Name = "Mage1";

        // var mage2 = new GameCharacter(mageTemplate);
        // mage2.Name = "Mage2";
        // mage1.Display();
        // mage2.Display();

        var rogueTemplate = new GameCharacter
        {
            Name = "RogueTemplate",
            Health = 100,
            Mana = 50,
            Strength = 60
        };

        var rouge1 = rogueTemplate.Clone();
        rouge1.Name = "Rogue1";

        var rouge2 = rogueTemplate.Clone();
        rouge2.Name = "Rogue2";

        rouge1.Display();
        rouge2.Display();

        var warriorTemplate = new GameCharacter
        {
            Name = "WarriorTemplate",
            Health = 150,
            Mana = 20,
            Strength = 80
        };

        var warrior1 = warriorTemplate.Clone();
        warrior1.Name = "Warrior1";

        var warrior02 = warriorTemplate.Clone();
        warrior02.Name="Warrior2";

        warrior1.Display();
        warrior1.Display();

        Shape circle = new Circle(5, "Red");
        Shape rectangle = new Rectangle(10,20,"Blue");
        Shape triangle = new Triangle(3, 4, 5,"Green");

        Shape circleCopy =(Shape) circle.Clone();
        Shape rectangleCopy =(Shape) rectangle.Clone();
        Shape triangleCopy = (Shape)triangle.Clone();
        circleCopy.Color = "Yellow";


        circle.Describe();
        circleCopy.Describe();
        rectangle.Describe();
        rectangleCopy.Describe();
        triangle.Describe();
        triangleCopy.Describe();

       
    }
}