namespace VisitorPattern.ObserverPattern
{
    public interface IObserver
    {
        void Update(Video video);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public class  VideoProcessor : ISubject
    {
        private readonly List<IObserver> _observer = new();
        public void Attach(IObserver observer)=>_observer.Add(observer);
        public void Detach(IObserver observer) => _observer.Remove(observer);

        public void Process(Video video)
        {
            Transcode(video);
        }

        public void Notify(Video video)
        {
            foreach (var item in _observers)
            {
                item.Update(video);
            }
        }
    }

    public class EmailNotifier : IObserver
    {
        public void Update(Video video)
        => EmailService.Notify(video.OwnerEmail, $"Your video {video.Id} is done.");
    }

    public class DatabaseLogger : IObserver
    {
        public void Update(Video video)
            => LogService.Log($"[Audit] Video {video.Id} processed at {DateTime.UtcNow}");
    }

    public class DashboardUpdater : IObserver
    {
        public void Update(Video video)
            => DashboardService.UpdateCount();
    }
}