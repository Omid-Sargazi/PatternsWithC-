using System.Runtime.CompilerServices;

namespace PatternsInCSharp02.ObserverPattern
{
    public interface IMetricObserver
    {
        List<string> InterestedMetrics {get;}
        Task UpdateAsync(string metricName, double value);
    }

    public class DashboardObserver : IMetricObserver
    {
        public List<string> InterestedMetrics => new List<string> {"CPU"};

        public async Task UpdateAsync(string metricName, double value)
        {
            if(value > 90)
            {
                Console.WriteLine($"Dashboard updated: {metricName} = {value}");
            }
        }
    }

    public class LoggingObserver : IMetricObserver
    {
        public List<string> InterestedMetrics => new List<string>{"Memory"};

        public async Task UpdateAsync(string metricName, double value)
        {
            Console.WriteLine($"LOG: {metricName} changed to {value}");
        }
    }

    public class AlertObserver : IMetricObserver
    {
        public List<string> InterestedMetrics => new List<string>{"Disk"};

        public async Task UpdateAsync(string metricName, double value)
        {
                Console.WriteLine($"ALERT: {metricName} exceeded threshold: {value}");
        }
    }

    public class MetricSubject
    {
        private List<IMetricObserver> _observers = new List<IMetricObserver>();
        private Dictionary<string,double> _metrics = new Dictionary<string,double>();

        public void Attach(IMetricObserver observer){
            _observers.Add(observer);
        }

        public void Detach(IMetricObserver observer)
        {
            _observers.Remove(observer);
        }

        public async Task SetMetric(string name, double value)
        {
            _metrics[name] = value;
            foreach(var observer in _observers)
            {
                if(observer.InterestedMetrics.Contains(name))
                {
                    observer.UpdateAsync(name, value);
                }
            }

            // var tasks = _observers.Select(o => o.UpdateAsync(name, value));
            // await Task.WhenAll(tasks);
            NotifyObservers(name, value);


        }

        private void NotifyObservers(string name, double value)
        {
            foreach(var observer in _observers)
            {
                observer.UpdateAsync(name, value);
            }
        }
    }
}