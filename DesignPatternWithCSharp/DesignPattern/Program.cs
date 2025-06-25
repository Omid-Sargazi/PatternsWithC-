using DesignPattern.PrototypePattern;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"DesignPattern");

        BasicCar nano_base = new Nano("Grean Nano") { Price = 100000 };
        BasicCar ford_base = new Ford("Ford Yellow") { Price = 500000 };
        BasicCar bc1;
        bc1 = nano_base.Clone();
        bc1.Price = nano_base.Price + BasicCar.SetPrice();
        Console.WriteLine($"Car is {0}, and it's price is Rs.{1}"+bc1.ModelName+" "+ bc1.Price);
    }
}