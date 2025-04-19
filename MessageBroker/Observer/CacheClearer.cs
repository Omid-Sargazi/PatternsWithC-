namespace MessageBroker.Observer
{
    public class CacheClearer : IContentListener
    {
        public void OnContentPublished(string title, string author, string content)
        {
            Console.WriteLine($"Cache cleared for: {title} by {author}");
        }
    }
}