using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace AdventureWorksConsole.ObserverPattern
{
    public interface IObserver
    {
        void Update(float temp);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObserver();
    }

    public class WeatherStation : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private float _temp;

        public void NotifyObserver()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_temp);
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }
    }

    public class MobileDisplay : IObserver
    {
        public void Update(float temp)
        {
            Console.WriteLine($"نمایشگر موبایل: دما {temp}°C است.");
        }
    }

    public class WebDisplay : IObserver
    {
        public void Update(float temp)
        {
            Console.WriteLine($"نمایشگر وب‌سایت: دما {temp}°C است.");
        }
    }
}