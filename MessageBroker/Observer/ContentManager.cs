using System.Globalization;

namespace MessageBroker.Observer
{
    public class ContentManager 
    {
        private List<IContentListener> _listeners = new List<IContentListener>();
        public ContentManager()
        {
            _listeners.Add(new EmailNotifier());
            _listeners.Add(new AdminNotifier());
            _listeners.Add(new AnalyticsUpdater());
            _listeners.Add(new CacheClearer());
        }
        public void PublishContent(string content, string author, string title)
        {
            SaveToDatabase(content, author, title);
            foreach(var item in _listeners)
            {
                item.OnContentPublished(title, author, title);
            }
            Console.WriteLine($"محتوای '{title}' منتشر شد!");
        }

        private void SaveToDatabase(string content, string autho, string title)
        {
            Console.WriteLine($"ذخیره محتوا در پایگاه داده: {title}");
        }
    }
}