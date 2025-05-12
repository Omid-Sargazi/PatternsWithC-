namespace BehavioralPattern02.ObserverPattern
{
    public interface IWeatherObserver
    {
        void Update(float temp, float humidity);
    }
    public class WeatherStation
    {
        public float Temperature {get; private set;}
        public float Humidity {get; private set;}

        private List<IWeatherObserver> _weatherObservers;
        public WeatherStation()
        {
            _weatherObservers = new List<IWeatherObserver>();
        }

        public void Attach(IWeatherObserver observer)
        {
            _weatherObservers.Add(observer);
        }
        public void Detach(IWeatherObserver observer)
        {
            _weatherObservers.Remove(observer);
        }
        public void SetMeasurements(float temp, float humidity)
        {
            Temperature = temp;
            Humidity = humidity;
            NotifyObservers();
            
        }

        private void NotifyObservers()
        {
            foreach(var oberver in _weatherObservers)
            {
                oberver.Update(Temperature, Humidity);
            }
        }
    }

    public class MobileAppDisplay : IWeatherObserver
    {
       

        public void Update(float temp, float humidity)
        {
             Console.WriteLine($"[Mobile] Temp: {temp}°C, Humidity: {humidity}%");
        }
    }

    public class WebDashboardDisplay : IWeatherObserver
    {
      

        public void Update(float temp, float humidity)
        {
             Console.WriteLine($"[Web] Temp: {temp}°C, Humidity: {humidity}%");
        }
    }

    public class LoggerDisplay : IWeatherObserver
    {
        public void Update(float temp, float humidity)
        {
            Console.WriteLine($"[Logger] Saving temp: {temp}, humidity: {humidity} to log.");
        }
    }

}