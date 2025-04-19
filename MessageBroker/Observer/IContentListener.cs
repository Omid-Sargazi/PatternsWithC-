namespace MessageBroker.Observer
{
    public interface IContentListener
    {
        void OnContentPublished(string title, string author, string content);
    }
}