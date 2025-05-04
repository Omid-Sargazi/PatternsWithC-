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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }

    public interface Visitor
    {
        public void Visit(StoryBook storyBook);
        public void Visit(SienceBook sienceBook);
        public void Visit(Magazine magazine);
    }

    
}