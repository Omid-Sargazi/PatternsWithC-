using PatternsInCSharp.ObserverPattern;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello");
        // var MonitoringSystem = new MonitoringSystem();

        // MonitoringSystem.Run();

        var newslette = new  NewsletterSystem();
        Action<string> sportFan = (news)=>Console.WriteLine($"sport:{news}");
        Action<string> techFan = (news)=>Console.WriteLine($"sport:{news}");

        newslette.Subscribe("sport", sportFan);
        newslette.Subscribe("tech", techFan);

        newslette.PublishNews("sport", "Sport news");
        newslette.PublishNews("sport", "Sport news2");
        newslette.PublishNews("sport", "Sport news3");
        newslette.PublishNews("sport", "Sport news4");
        newslette.PublishNews("tech", "Tech news");



    }
}