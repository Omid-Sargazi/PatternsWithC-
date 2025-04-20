namespace MessageBroker.Observer
{
    public interface IContentObserver
    {
        bool IsInterestedIn(ContentEventType eventType, string category);
        void Update(ContentEventType eventType, ContentInfo contentInfo);
    }
}