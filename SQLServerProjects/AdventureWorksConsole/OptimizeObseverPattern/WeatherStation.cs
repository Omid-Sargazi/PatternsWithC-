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
        public void Subscribe(WeatherStation station)
        {
            station.TemperatureChanged += Update;
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