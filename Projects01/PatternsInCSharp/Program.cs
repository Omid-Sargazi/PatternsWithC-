﻿using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using PatternsInCSharp.ObserverPattern;

public class Program
{

    public delegate void MyDelegate(string message);
    public static async Task Main(string[] args)
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

        var registaration = new UserRegistration();
        await registaration.RegisterUserAsync("o@o.com");
        Console.WriteLine("complete resgistration");

        MyDelegate del = PrintMessage;
        del("Hello from delegate");

    }

    public static void PrintMessage(string message)
    {
        Console.WriteLine($"Mesasag from delegate:{message}");
    }
}