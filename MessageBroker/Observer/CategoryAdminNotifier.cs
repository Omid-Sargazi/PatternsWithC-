namespace MessageBroker.Observer
{
    public class CategoryAdminNotifier : IContentObserver
    {
        private readonly string _categoryResponsibility;
        public CategoryAdminNotifier(string category)
        {
            _categoryResponsibility = category;
        }
        public bool IsInterestedIn(ContentEventType eventType, string category)
        {
            return category == _categoryResponsibility;
        }

        public void Update(ContentEventType eventType, ContentInfo contentInfo)
        {
            Console.WriteLine($"ارسال نوتیفیکیشن به مدیران دسته {_categoryResponsibility}: {eventType} محتوای {contentInfo.Title}");
        }
    }
}