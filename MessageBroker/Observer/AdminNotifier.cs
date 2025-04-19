namespace MessageBroker.Observer
{
    public class AdminNotifier : IContentListener
    {
        public void OnContentPublished(string title, string author, string content)
        {
            Console.WriteLine($"Admin notified: {title} by {author}");
        }
    }
}