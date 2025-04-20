namespace MessageBroker.Observer
{
    public class ContentInfo
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public string Category { get; set; }
        public ContentInfo(string title, string author, string content, DateTime publishDate, string category)
        {
            Title = title;
            Author = author;
            Content = content;
            PublishDate = publishDate;
            Category = category;
        }
        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Content: {Content}, PublishDate: {PublishDate}, Category: {Category}";
        }
    }
}