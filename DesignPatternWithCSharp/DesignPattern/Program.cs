using DesignPattern.BuilderPattern;
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
        Console.WriteLine($"Car is {0}, and it's price is Rs.{1}" + bc1.ModelName + " " + bc1.Price);


        Employee original1 = new Employee();
        original1.Name = "Omid";
        original1.Department = "Software";
        original1.Address = "1232 Main St Australia";

        Console.WriteLine("Original Employee");
        original1.Display();

        Employee clone = (Employee)original1.Clone();
        clone.Address = "NYC";
        clone.Name = "Saeed";
        Console.WriteLine("\nOriginal Employee after cloning");
        clone.Display();

        Console.WriteLine("\nOriginal Employee after cloning");
        original1.Display();

        Console.WriteLine("***************************Builder****************");
        var builder = new CheeseBurgerBuilder();
        var chef = new BurgerChef(builder);

        chef.MakeBuilder();
        var burger = builder.GetBurger();
        burger.Display();
        Console.WriteLine("***************************Prototype Pattern****************");


        IInvitationCard prototype = new BirthdayCard("BirthdayCard",
        "Happy Birthday to", "", "", "Sam");
        prototype.Display();

        IInvitationCard customer02 = prototype.Clone();
        ((InvitationCard)customer02).Message = "Happy Birthday to Tina";
        customer02.Display();



    }
}