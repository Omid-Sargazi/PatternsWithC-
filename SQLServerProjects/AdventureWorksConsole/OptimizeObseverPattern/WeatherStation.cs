namespace AdventureWorksConsole.OptimizeObseverPattern
{
    public class WeatherStation
    {
        private float _temp;
        public event Action<float> TemperatureChanged;
        public void SetTemperature(float temp)
        {
            _temp = temp;
            TemperatureChanged?.Invoke(_temp);
        }
    }

    public class MobileDisplay
    {
        private WeatherStation _station;
        public void Subscribe(WeatherStation station)
        {
            _station = station;
            _station.TemperatureChanged += Update;
        }

        public void Unsubscribe()
        {
            if (_station != null)
            {
                _station.TemperatureChanged -= Update;
                _station = null;
            }
        }

        public void Update(float temp)
        {
            Console.WriteLine($"نمایشگر موبایل: دما {temp}°C است.");
        }
    }

    public class WebDisplay
    {
        public void Subscribe(WeatherStation station)
        {
            station.TemperatureChanged += Update;
        }

        private void Update(float temp)
        {
            Console.WriteLine($"نمایشگر وب‌سایت: دما {temp}°C است.");
        }
    }
}