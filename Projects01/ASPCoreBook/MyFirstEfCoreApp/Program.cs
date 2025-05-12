using MyFirstEfCoreApp.Data;
using MyFirstEfCoreApp.Models;

public class Program
{
    public static void Main(string[] args)
    {
        using var db = new AppDbContext();
        db.Database.EnsureCreated();
        if (!db.Books.Any())
        {
            db.Books.Add(new Book { Title = "C# in depth", Author = "Jon Skeet" });
            db.Books.Add(new Book { Title = "Entity Framework Core in Action", Author = "Jon P Smith" });
            db.SaveChanges();
        }

        var books = db.Books.ToList();
        Console.WriteLine("Books in database:");
        foreach (var book in books)
        {
            Console.WriteLine($"- {book.Title} by {book.Author}");
        }
    }
}