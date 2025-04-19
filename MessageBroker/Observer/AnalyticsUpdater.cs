namespace MessageBroker.Observer
{
    public class AnalyticsUpdater : IContentListener
    {
        public void OnContentPublished(string title, string author, string content)
        {
            Console.WriteLine($"Analytics updated for: {title} by {author}");
        }
    }
}