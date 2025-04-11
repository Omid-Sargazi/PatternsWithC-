namespace CompositePattern.GRASP
{
    public class Library
    {
        private List<Book> _books = new List<Book>();
        private BorrowingManager _borrowingManager = new BorrowingManager();
        // private Dictionary<string, string> _borrowers = new Dictionary<string, string>(); // title -> user
        public void AddBook(string title, string author)
        {
            var book = new Book {Title = title, Author = author, IsBorrowed = false};
            _books.Add(book);
            Console.WriteLine($"Added {title} by {author}");
        }
        public void BorrowBook(string title, User userName)
        {
            var book = _books.FirstOrDefault(b => b.Title==title);
           
                if(book != null)
                {
                //    var user = new User {Name = userName};
                _borrowingManager.BorrowBook(book, userName);
                }

            
            Console.WriteLine($"{title} not available");
        }

        public void ShowInventory()
        {
            Console.WriteLine("Library Inventory:");
        foreach (var book in _books)
        {
            Console.WriteLine($"{book.Title} by {book.Author} - {(book.IsBorrowed ? "Borrowed" : "Available")}");
        }
        }
    }
}