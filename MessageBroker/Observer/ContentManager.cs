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

        public void Attach(IContentListener listener)
        {
            _listeners.Add(listener);
        }

        public void Detach(IContentListener listener)
        {
            _listeners.Remove(listener);
        }

        private void Notify(string title, string author, string content)
        {
            foreach (var item in _listeners)
            {
                item.OnContentPublished(title, author, content);
            }
        }
        public void PublishContent(string content, string author, string title)
        {
            SaveToDatabase(content, author, title);

            
            Notify(title, author, content);


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