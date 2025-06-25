namespace DesignPattern.PrototypePattern;

public interface IEmployeePrototype
{
    IEmployeePrototype Clone();
    void Display();
}

public class Employee : IEmployeePrototype
{
    public string Name { get; set; }
    public string Department { get; set; }
    public string Address { get; set; }
    public IEmployeePrototype Clone()
    {   //shalow copy
        return (IEmployeePrototype)this.MemberwiseClone();
    }

    public void Display()
    {
        Console.WriteLine($"Name: {Name},Department: {Department},Address: {Address}");
    }
}
