namespace AdventureWorksConsole.OptimizeObseverPattern
{

    public class WeatherData
    {
        public float Temperature { get; }
        public DateTime Timestamp { get; }
        public WeatherData(float temp)
        {
            Temperature = temp;
            Timestamp = DateTime.Now;
        }
    }
    public class WeatherStation
    {
        private float _temp;
        public event Action<WeatherData> WeatherChanged;

       
        public void SetTemperature(float temp)
        {
            _temp = temp;
            WeatherChanged?.Invoke(new WeatherData(_temp));
        }
    }

    public class MobileDisplay
    {
        private WeatherStation _station;
        public void Subscribe(WeatherStation station)
        {
            _station = station;
            _station.WeatherChanged += Update;
        }

        public void Unsubscribe()
        {
            if (_station != null)
            {
                _station.WeatherChanged -= Update;
                _station = null;
            }
        }

        public void Update(WeatherData temp)
        {
            Console.WriteLine($"نمایشگر موبایل: دما {temp}°C است.");
        }
    }

    public class WebDisplay
    {
        private WeatherStation _station;
        public void Subscribe(WeatherStation station)
        {
            _station = station;
            _station.WeatherChanged += Update;
        }

        public void Unsubscribe()
        {
            if (_station != null)
            {
                _station.WeatherChanged -= Update;
                _station = null;
            }
        }

        private void Update(WeatherData temp)
        {
            Console.WriteLine($"نمایشگر وب‌سایت: دما {temp}°C است.");
        }
    }
}