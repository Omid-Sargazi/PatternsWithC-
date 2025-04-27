namespace PatternsInCSharp.ProxyPattern
{
    public class Book 
    {
        public string Title {get; set;}
        public string Author {get; set;}
        public string Content {get; set;}

        public Book(string title, string author, string content)
        {
            Title = title;
            Author = author;
            Content = content;
        }
    }

    public class BookReader : IBookReader
    {
        private readonly string _bookId;
        private Book _book;

        public BookReader(string bookId)
        {
            _bookId = bookId;
            _book = LoadBookFromSever();
        }

        private Book LoadBookFromSever()
        {
            Console.WriteLine($"Loading book {_bookId} from server...");
            Thread.Sleep(2000);
            return new Book("Sample Title", "Sample Author", "This is the heavy content of the book...");
        }

        public string GetTitle()
        {
            _book??=LoadBookFromSever();
            return _book.Title;
        }
        public string GetAuthor()
        {
            _book??=LoadBookFromSever();
            return _book.Author;
        }
        public string GetContent()
        {
            _book??=LoadBookFromSever();
            return _book.Content;
        }
    }

    public interface IBookReader
    {
        string GetTitle();
        string GetAuthor();
        string GetContent();
    }

    public class BookReaderProxy : IBookReader
    {
        private readonly string _bookId;
        private BookReader _realReader;
        private Book _book;
        private readonly bool _isVipUser;


        public BookReaderProxy(string bookId, bool isVipUser)
        {
            _bookId = bookId;
            _book = new Book("Sample Title", "Sample Author", "This is the heavy content of the book...");
            _isVipUser = isVipUser;
        }
        public string GetAuthor()
        {
            return _book.Author;
        }

        public string GetContent()
        {
            if(!_isVipUser)
                throw new UnauthorizedAccessException("You are not authorized to access the content of this book.");
            _realReader ??=new BookReader(_bookId);
            return _realReader.GetContent();
        }

        public string GetTitle()
        {
            return _book.Title;
        }
    }
}