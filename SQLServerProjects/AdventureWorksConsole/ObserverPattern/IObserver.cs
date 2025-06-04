namespace AdventureWorksConsole.ObserverPattern
{
    public interface IObserver
    {
        void Update(float temp);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObserver();
    }

    public class WeatherStation : ISubject
    {
        public void NotifyObserver()
        {
            throw new NotImplementedException();
        }

        public void RegisterObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void RemoveObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }
    }
}