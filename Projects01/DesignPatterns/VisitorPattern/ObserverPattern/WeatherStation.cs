namespace VisitorPattern.ObserverPattern
{
    public interface IObserver
    {
        void Update(float temp);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public class WeatheStation : ISubject
    {
        private readonly List<IObserver> _observer = new();
        private float _temp;

        public void Attach(IObserver observer)
        {
            _observer.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observer.Remove(observer);
        }

        public void SetTemperature(float temp)
        {
            _temp = temp;
            Notify();
        }

        public void Notify()
        {
            foreach(var observer in _observer)
            {
                observer.Update(_temp);
            }
        }
    }

    public class Display : IObserver
    {
        public void Update(float temp)
        {
            Console.WriteLine($"Display: {temp}°C");
        }
    }
}