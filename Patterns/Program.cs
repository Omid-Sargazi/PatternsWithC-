using Patterns.AdapterPattern;
using Patterns.CommandPattern.WithoutPattern;
using Patterns.CompositePattern.MenuRestuant;
using Patterns.CommandPattern.WithPattern;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("hello");
        // var media = new MediaPlayer();
        // media.Paly("mp3", "song.mp3");
        // media.Paly("wav", "moderntalking.wav");

        // var menu = new Menu("Main Course");
        // menu.Add(new MenuItem("Grilled Chicken",15));
        // var subMenu = new Menu("Vegetarian");
        // menu.Add(subMenu);
        // subMenu.Add(new MenuItem("Paneer Tikka", 12));
        // subMenu.Add(new MenuItem("Veg Biryani", 10));
        // var subMenu02 = new Menu("Non-Vegetarian");
        // menu.Add(subMenu02);
        // subMenu02.Add(new MenuItem("Chicken Biryani",14));
        // menu.Display();

        // Television tv = new Television();
        // Patterns.CommandPattern.WithPattern.RemoteController remote = new Patterns.CommandPattern.WithPattern.RemoteController(new TurnOnOperation(tv), new TurnOffOperation(tv));
        
        
    }
}