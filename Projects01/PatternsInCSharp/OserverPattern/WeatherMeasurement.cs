using System.Net.NetworkInformation;

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
    public interface IWeatherObserver
    {
        HashSet<WeatherDataType> InterestedDataTypes {get;}
        void Update(WeatherMeasurement measurement);
    }

    public enum WeatherDataType
    {
        Temperature,
        Humidity,
        Pressure
    }


    public class WeatherData
    {
        private WeatherMeasurement _lastMeasurement;
        private readonly object _lock = new object();
        private readonly List<IWeatherObserver> _observers = new List<IWeatherObserver>();


        public void RegisterObserver(IWeatherObserver observer)
        {
            lock(_lock)
            {
                _observers.Add(observer);
            }
        }

        public void RemoveObserver(IWeatherObserver observer)
        {
            lock(_lock)
            {
                _observers.Remove(observer);
            }
        }

        private void NotifyObservers(WeatherMeasurement measurement)
        {
            IWeatherObserver[] observersSnapshot;
            lock(_lock)
            {
                observersSnapshot = _observers.ToArray();
            }

            Parallel.ForEach(observersSnapshot, observer=>{
                bool shouldNotify = observer.InterestedDataTypes.Any(datatype=> 
                datatype switch
                {
                    WeatherDataType.Temperature => measurement.Temperature != _lastMeasurement.Temperature,
                    WeatherDataType.Humidity => measurement.Humidity != _lastMeasurement?.Humidity,
                    WeatherDataType.Pressure => measurement.Pressure != _lastMeasurement?.Pressure,
                    _ => false
                }
                );

                if(shouldNotify)
                {
                    observer.Update(measurement);
                }
            });
        }
    }
}