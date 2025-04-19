namespace MessageBroker.Observer
{
    public class EmailNotifier : IContentListener
    {
        public void OnContentPublished(string title, string author, string content)
        {
            Console.WriteLine($"Email sent to subscribers: {title} by {author}");
        }
    }
}