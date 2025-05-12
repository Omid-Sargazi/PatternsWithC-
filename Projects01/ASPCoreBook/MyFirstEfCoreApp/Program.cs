using Microsoft.EntityFrameworkCore;
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
        }
        var bookReview = db.Books.FirstOrDefault(b=>b.Title=="C# in depth");
        if(bookReview !=null)
        {
            bookReview.Reviews.Add(new Review {Reviewer = "Mark",Rating = 5});
            bookReview.Reviews.Add(new Review{Reviewer = "Tony", Rating=3});
        }
            db.SaveChanges();

        var books = db.Books.ToList();
        Console.WriteLine("Books in database:");
        foreach (var book in books)
        {
            Console.WriteLine($"- {book.Title} by {book.Author}");
        }
        books = db.Books.Where(b => b.Author == "Jon Skeet").ToList();
        foreach(var book in books)
        {
            Console.WriteLine($"{book.Title} by {book.Author}");
        }

       var bookk = db.Books.FirstOrDefault(b => b.Title == "C# in depth");
        Console.WriteLine($"{bookk?.Author ?? "Book Not Found"}");

        books = db.Books.OrderBy(b =>b.Title).ToList();
        Console.WriteLine("Sorted books are: ");
        foreach(var book in books)
        {
            Console.WriteLine($"{book.Title} by {book.Author}");
        }

        books = db.Books.OrderByDescending(b => b.BookId).ToList();
        books  = db.Books.Where(b => b.Title.Contains("C#")).ToList();// every books that have C# in their name.
        books = db.Books.Where(b => b.BookId<3).ToList();

        books  = db.Books.Take(5).ToList();
        books = db.Books.Skip(5).Take(5).ToList();

        var booksWithReviews = db.Books.Include(b => b.Reviews).ToList();
        foreach(var book in booksWithReviews)
        {
            Console.WriteLine($"{book.Title} by {book.Author}");
            foreach(var review in book.Reviews)
            {
                Console.WriteLine($"{review.Reviewer} : {review.Rating}");
            }
        }

    }
}