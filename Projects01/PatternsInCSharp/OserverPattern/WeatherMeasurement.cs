namespace PatternsInCSharp.ObserverPattern
{
    public class WeatherMeasurement
    {
        public float Temperature { get; }
        public float Humidity { get; }
        public float Pressure { get; }

        public WeatherMeasurement(float temperature, float humidity, float pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }

        public override bool Equals(object obj)
        {
          if (obj is WeatherMeasurement other)
        {
            return Temperature == other.Temperature &&
                   Humidity == other.Humidity &&
                   Pressure == other.Pressure;
        }
        return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Temperature,Humidity, Pressure);
        }
    }
}