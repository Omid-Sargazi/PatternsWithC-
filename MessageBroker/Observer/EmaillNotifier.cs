namespace MessageBroker.Observer
{
    public class EmaillNotifier : IContentObserver
    {
        public bool IsInterestedIn(ContentEventType eventType, string category)
        {
            return eventType == ContentEventType.Created;
        }

        public void Update(ContentEventType eventType, ContentInfo contentInfo)
        {
            Console.WriteLine($"ارسال ایمیل به مشترکین درباره: {contentInfo.Title} در دسته {contentInfo.Category}");
        }
    }
}