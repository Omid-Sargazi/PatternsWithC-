namespace BehavioralPattern02.ObserverPattern
{
    public class WeatherStation
    {
        public float Temperature {get; private set;}
        public float Humidity {get; private set;}
        public void SetMeasurements(float temp, float humidity)
        {
            Temperature = temp;
            Humidity = humidity;
        }
    }
}