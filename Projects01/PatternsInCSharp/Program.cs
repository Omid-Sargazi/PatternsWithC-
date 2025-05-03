using PatternsInCSharp.ObserverPattern;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello");
        var MonitoringSystem = new MonitoringSystem();

        MonitoringSystem.Run();
    }
}