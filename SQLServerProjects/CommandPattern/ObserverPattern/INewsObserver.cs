namespace CommandPattern.ObserverPattern
{
    public interface INewsObserver
    {
        void Update(string news);
    }

    public class NewsAgency
    {
        private string _name;
        private string latestNews;
        private List<INewsObserver> _observers = new List<INewsObserver>();
        public NewsAgency(string name)
        {
            _name = name;
        }

        public void AddObserver(INewsObserver observer)
        {
            _observers.Add(observer);
            Console.WriteLine($"Observer subscribed to {_name}.");
        }

        public void RemoveObserver(INewsObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine($"Observer unsubscribed from {_name}.");
        }

        public void PublishNews(string news)
        {
            latestNews = news;
            Console.WriteLine($"{_name} published news: {news}");
            NotifyObservers();
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(latestNews);
            }
        }
    }
    public class EmailSubscriber : INewsObserver
    {
        private string _name;
        public EmailSubscriber(string name)
        {
            _name = name;
        }
        public void Update(string news)
        {
            Console.WriteLine($"{_name} received email: {news}");
        }
    }

    public class NotificationSubscriber : INewsObserver
    {
        private string _name;
        public NotificationSubscriber(string name)
        {
            _name = name;
        }
        public void Update(string news)
        {
            Console.WriteLine($"{_name} received notification: {news}");
        }
    }
}