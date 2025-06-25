namespace DesignPattern.ObserverPattern
{
   public interface ISocialObserver
   {
        void Update(string celebrityName, string tweet);
   }

   public interface ISocialSubject
   {
        void Register(ISocialObserver observer);
        void Unregister(ISocialObserver observer);
        void Notify(string tweet);
   }

   public class  CelebritySocial : ISocialSubject
   {
        private list<ISocialObserver> _observers;
        public string Name {get; set;}

        public CelebritySocial(string name)
        {
            Name = name;
            _observers = new List<ISocialObserver>();
        }


        public void Tweet(string tweet)
        {
            Console.WriteLine($"{Name} said {tweet}");
            Notify(tweet);
        }

        public void Register(ISocialObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unregister(ISocialObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string tweet)
        {
            foreach (var observer in _observers)
            {
                observer.Update(Name,tweet);
            }
        }
   }

   public class Followewr01: ISocialObserver
   {
    private string Name {get; set;}
    public Followewr01(string name)
    {
        Name = name;
    }
    public void Update(string celebrityName01,string tweet)
    {
        Console.WriteLine($"{Name} received {tweet} form {celebrityName}")
    }
   }

   public class Followewr02: ISocialObserver
   {
        private string Name {get; set;}
        public Followewr02(string name)
        {
            Name = name;
        }
        public void Update(string celebrityName01,string tweet)
        {
            Console.WriteLine($"{Name} received {tweet} form {celebrityName}")
        }
   }
}