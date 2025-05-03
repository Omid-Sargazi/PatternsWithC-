namespace PatternsInCSharp.ObserverPattern
{
    public class NewsletterSystem
    {
        private Dictionary<string, List<Action<string>>> _subscribers = new Dictionary<string, List<Action<string>>>();

        public void Subscribe(string topic, Action<string> callback)
        {
            if(!_subscribers.ContainsKey(topic))
                _subscribers[topic] = new List<Action<string>>();
            _subscribers[topic].Add(callback);
        }

        public void Unsubscribe(string topic, Action<string> callback)
        {
            if(_subscribers.ContainsKey(topic))
                _subscribers[topic].Remove(callback);
        }

        public void PublishNews(string topic, string news)
        {
            if(_subscribers.ContainsKey(topic))
                foreach(var subscribe in _subscribers[topic])
                {
                    subscribe(news);
                }
        }
    }
}