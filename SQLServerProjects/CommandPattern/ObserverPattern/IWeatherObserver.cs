namespace CommandPattern.ObserverPattern
{
    public interface IWeatherObserver
    {
        void Update(string temp);
    }


    public class WeatherStation
    {
        private string _temp;
        private List<IWeatherObserver> _observers = new List<IWeatherObserver>();
        public WeatherStation(string temp)
        {
            _temp = temp;
        }
        public void RegisterObserver(IWeatherObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IWeatherObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotificationObserver()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_temp);
            }
        }





    }

    public class MobileNotify : IWeatherObserver
    {
        public void Update(string temp)
        {
            Console.WriteLine($"the temp is showed in the mobile.");
        }
    }

    public class ScreenNotify : IWeatherObserver
    {
        public void Update(string temp)
        {
            Console.WriteLine($"the temp is showed in the Screen.");
            
        }
    }
}