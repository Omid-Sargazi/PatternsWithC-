using Patterns.AdapterPattern;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("hello");
        var media = new MediaPlayer();
        media.Paly("mp3", "song.mp3");
        media.Paly("wav", "moderntalking.wav");
    }
}