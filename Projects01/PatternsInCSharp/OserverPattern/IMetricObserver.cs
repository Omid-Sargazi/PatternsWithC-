namespace PatternsInCSharp.ObserverPattern
{
   public interface IMetricObserver
   {
        void Update(string metricName, double value);
   }

    public class DashboardObserver : IMetricObserver
    {
        public void Update(string metricName, double value)
        {
            Console.WriteLine($"Dashboard updated: {metricName} = {value}");
        }
    }

    public class AlertObserver : IMetricObserver
    {
        public void Update(string metricName, double value)
        {
            Console.WriteLine($"ALERT: {metricName} exceeded threshold: {value}");
        }
    }

    public class LoggingObserver : IMetricObserver
    {
        public void Update(string metricName, double value)
        {
            Console.WriteLine($"LOG: {metricName} changed to {value}");
        }
    }

    public class MetricSubject
    {
        private List<IMetricObserver> _observer = new List<IMetricObserver>();
        private Dictionary<string, double> _metrics = new Dictionary<string, double>();

        public void Attach(IMetricObserver observer)

        {
            _observer.Add(observer);
        }

        public void Detach(IMetricObserver observer)
        {
            _observer.Remove(observer);
        }

        public void SetMetric(string name, double value)
        {
            _metrics[name] = value;
            NotifyObservers(name, value);

        }

        private void NotifyObservers(string name, double value)
        {
            foreach (var observer in _observer)
            {
                observer.Update(name, value);
            }
        }
    }

    public class MonitoringSystem
    {
        private MetricSubject _subject = new MetricSubject();
        public void Run()
        {
            _subject.Attach(new DashboardObserver());
            _subject.Attach(new AlertObserver());
            _subject.Attach(new LoggingObserver());

            for(int i=0; i< 100; i++)
            {
                _subject.SetMetric("CPU", new Random().NextDouble() * 100);
                _subject.SetMetric("Memory", new Random().NextDouble() * 100);
                _subject.SetMetric("Disk", new Random().NextDouble() * 100);
                _subject.SetMetric("CPU", new Random().NextDouble() * 100);

                Thread.Sleep(5000);
            }
        }
    }
}