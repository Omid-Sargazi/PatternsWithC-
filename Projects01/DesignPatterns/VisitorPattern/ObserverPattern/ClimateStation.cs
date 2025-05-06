namespace  VisitorPattern.ObserverPattern
{
    public class ClimateStation
    {
        private float temperator;
        public delegate void TemperatureChangedHandler(float newtemp);
        public event TemperatureChangedHandler? TemperatureChanged;

        public void SetTemperature(float temp)
        {
            temperator = temp;
            TemperatureChanged?.Invoke(temperator);
        }
    }

    public class Display
    {
        public void Subscribe(ClimateStation station)
        {
            station.TemperatureChanged +=OnTemperatureChanged;
        }

        private void OnTemperatureChanged(float temp) {
        Console.WriteLine($"[Display] دمای جدید: {temp}°C");
    }
    }

    class Alarm {
    public void Subscribe(WeatherStation station) {
        station.TemperatureChanged += OnTemperatureChanged;
    }

    private void OnTemperatureChanged(float temp) {
        if (temp > 40)
            Console.WriteLine($"[Alarm] هشدار! دما خیلی بالا رفته: {temp}°C");
    }
}
}