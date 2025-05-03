namespace PatternsInCSharp.ObserverPattern
{
   public interface IMetricObserver
   {
        List<string> InterestedMetrics {get;}
        Task Update(string metricName, double value);
   }

    public class DashboardObserver : IMetricObserver
    {
        public List<string> InterestedMetrics => new List<string>{"CPU", "Memory", "Disk"};

        public async Task Update(string metricName, double value)
        {
            Console.WriteLine($"Dashboard updated: {metricName} = {value}");
        }
    }

    public class AlertObserver : IMetricObserver
    {
        public List<string> InterestedMetrics => new List<string> {"CPU", "Memory"};

        public async Task Update(string metricName, double value)
        {
            Console.WriteLine($"ALERT: {metricName} exceeded threshold: {value}");
        }
    }

    public class LoggingObserver : IMetricObserver
    {
        public List<string> InterestedMetrics => new List<string> {"CPU"};

        public async Task  Update(string metricName, double value)
        {
            Console.WriteLine($"LOG: {metricName} changed to {value}");
        }
    }

    public class MetricSubject
    {
        private List<WeakReference<IMetricObserver>> _observer = new List<WeakReference<IMetricObserver>>();
        private Dictionary<string, double> _metrics = new Dictionary<string, double>();

        public void Attach(IMetricObserver observer)

        {
            _observer.Add(new WeakReference<IMetricObserver>(observer));
        }

        public void Detach(IMetricObserver observer)
        {
            _observer.Remove(new WeakReference<IMetricObserver>(observer));
        }

        public async Task SetMetricAsync(string name, double value)
        {

            // var tasks = _observer.Select(o => o.Update(name, value));
        // await Task.WhenAll(tasks);
        //     foreach(var observer in _observer)
        //     {
        //         if(observer.InterestedMetrics.Contains(name))
        //         {
        //             observer.Update(name, value);
        //         }
        //     }
            _metrics[name] = value;
            NotifyObservers(name, value);

        }

        private void NotifyObservers(string name, double value)
        {
            foreach (var weakRef in _observer.ToList())
            {
                if(weakRef.TryGetTarget(out var observer))
                    observer.Update(name, value);
                // _observer.Remove(name, value);
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
                _subject.SetMetricAsync("CPU", new Random().NextDouble() * 100);
                _subject.SetMetricAsync("Memory", new Random().NextDouble() * 100);
                _subject.SetMetricAsync("Disk", new Random().NextDouble() * 100);
                _subject.SetMetricAsync("CPU", new Random().NextDouble() * 100);

                Thread.Sleep(5000);
            }
        }
    }
}