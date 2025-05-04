namespace VisitorPattern.LibrarySystem
{
    public interface LibraryItem
    {
        void Accept(Visitor visitor);
    }
    public class StoryBook : LibraryItem
    {
        public string Title { get;}
        public int Pages { get;}
        public string Gener { get;}
        public StoryBook(string title, int pages, string gener)
        {
            Title = title;
            Pages = pages;
            Gener = gener;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class SienceBook : LibraryItem
     
    {
        public string Title {get;}
        public int Pages {get;}
        public string Topic {get;}
        public SienceBook(string title, int pages, string topic)
        {
            Title = title;
            Pages = pages;
            Topic = topic;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Magazine : LibraryItem
    {
        public string Title { get; }
        public int IssueNumber { get; }
        public int PublicationYear { get; }
        public Magazine(string title, int issueNumber, int publicationYear)
        {
            Title = title;
            IssueNumber = issueNumber;
            PublicationYear = publicationYear;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public interface Visitor
    {
        public void Visit(StoryBook storyBook);
        public void Visit(SienceBook sienceBook);
        public void Visit(Magazine magazine);
    }

    public class PageCountVisitor : Visitor
    {
        public int totalPages {get; private set;}
        public void Visit(StoryBook storyBook)
        {
            totalPages += storyBook.Pages;
        }

        public void Visit(SienceBook sienceBook)
        {
            totalPages += sienceBook.Pages;
        }

        public void Visit(Magazine magazine)
        {
            totalPages += magazine.IssueNumber;
        }
    }

    public class Library
    {
        private readonly List<LibraryItem> _items = new List<LibraryItem>();
        public void AddItem(LibraryItem item)
        {
            _items.Add(item);
        }

        public void Accept(Visitor visitor)
        {
            foreach(var item in _items)
            {
                item.Accept(visitor);
            }
        }
    }

    public class SummaryVisitor : Visitor
    {
        public void Visit(StoryBook storyBook)
        {
            Console.WriteLine($"StoryBook: {storyBook.Title}, Pages: {storyBook.Pages}, Genre: {storyBook.Gener}");
        }

        public void Visit(SienceBook sienceBook)
        {
            Console.WriteLine($"ScienceBook: {sienceBook.Title}, Pages: {sienceBook.Pages}, Topic: {sienceBook.Topic}");
        }

        public void Visit(Magazine magazine)
        {
            Console.WriteLine($"Magazine: {magazine.Title}, Issue: {magazine.IssueNumber}, Year: {magazine.PublicationYear}");
        }
    }

    public class ValidityVisitor : Visitor
    {
        public void Visit(StoryBook storyBook)
        {
            if (storyBook.Pages < 0)
            {
                Console.WriteLine($"Invalid StoryBook: {storyBook.Title} has negative pages.");
            }
            else
            {
                Console.WriteLine($"Valid StoryBook: {storyBook.Title}");
            }
        }

        public void Visit(SienceBook sienceBook)
        {
            if (sienceBook.Pages > 100)
            {
                Console.WriteLine($"Valid ScienceBook: {sienceBook.Title}");
            }
            else
            {
                Console.WriteLine($"Invalid ScienceBook: {sienceBook.Title} has negative pages.");
            }
        }

        public void Visit(Magazine magazine)
        {
            if (magazine.PublicationYear > 2025)
            {
                Console.WriteLine($"Valid Magazine: {magazine.Title}");
            }
            else
            {
                Console.WriteLine($"Invalid Magazine: {magazine.Title} has negative issue number.");
            }
        }
    }
}