namespace MyFirstEfCoreApp.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public List<Review> Reviews {get; set;} = new List<Review>();
    }

    public class Review
    {
        public int ReviewId {get; set;}
        public string Reviewer {get; set;}
        public int Rating {get; set;}
        public int BookId {get; set;}
        public Book Book {get; set;}
    }
}