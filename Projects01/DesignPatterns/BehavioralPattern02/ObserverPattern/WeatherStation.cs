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

        private MobileAppDisplay _mobileAppDisplay;
        private WebDashboardDisplay _webDashboardDisplay;
        public WeatherStation()
        {
            _mobileAppDisplay = new MobileAppDisplay();
            _webDashboardDisplay = new WebDashboardDisplay();
        }
        public void SetMeasurements(float temp, float humidity)
        {
            Temperature = temp;
            Humidity = humidity;
            _mobileAppDisplay.Display(Temperature,Humidity);
            _webDashboardDisplay.Display(Temperature,Humidity);
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