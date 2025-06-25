using DesignPattern.StrategyPattern;
using DesignPattern.ObserverPattern;
namespace DesignPattern
{

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var bird = new Bird(new FlyByWings());
        bird.performFly();

        bird = new Bird(new FlyByMotors());
        bird.performFly();

        bird = new Bird(new NoFly());
        bird.performFly();

        Console.WriteLine("/////////////////////");

        var pay = new Shpopping(new PayByCC());
        pay.performPay();

        pay = new Shpopping(new PayByPayPal());
        pay.performPay();

        Console.WriteLine("/////////////////////");
        
        Celebraty celeb1 = new Celebraty("celeb1");
        Celebraty celeb2 = new Celebraty("celeb2");

        ConcreateClassA follower1 = new ConcreateClassA("follower1");
        ConcreateClassA follower2 = new ConcreateClassA("follower2");
        ConcreateClassB follower3 = new ConcreateClassB("follower1");

        celeb1.RegisterObserver(follower1);
        celeb1.RegisterObserver(follower2);
        celeb2.RegisterObserver(follower2);
        celeb1.RegisterObserver(follower3);

        celeb1.Tweet("Message 1");

        Console.WriteLine("/////////////////////");
        
        celeb2.Tweet("message 02");


      
    }
}
}