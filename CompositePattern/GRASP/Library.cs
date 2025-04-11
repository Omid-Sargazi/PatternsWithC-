namespace CompositePattern.GRASP
{
    public class Library
    {
        private List<Book> _books = new List<Book>();
        // private Dictionary<string, string> _borrowers = new Dictionary<string, string>(); // title -> user
        public void AddBook(string title, string author)
        {
            var book = new Book {Title = title, Author = author, IsBorrowed = false};
            _books.Add(book);
            Console.WriteLine($"Added {title} by {author}");
        }
        public void BorrowBook(string title, string user)
        {
            foreach(var book in _books)
            {
                if(book.Title == title && !book.IsBorrowed)
                {
                    book.IsBorrowed = true;
                    // _borrowers[title] = user;
                    Console.WriteLine($"Borrowed {title}");
                    return;
                }

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