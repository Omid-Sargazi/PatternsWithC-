namespace DesignPattern.ObserverPattern
{
    public interface IObserver
    {
        void Update(string celebratyName, string tweet);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void Unregister(IObserver observer);
        void Notify(string tweet);
    }

    public class Celebraty : ISubject
    {
        public string Name {get; set;}
        private List<IObserver> _observerList;
        public Celebraty(string name)
    {
        Name = name;

        _observerList = new List<IObserver>();
    }

    public void Tweet(string tweet)
    {
        Console.WriteLine($"{Name} said,{tweet}");
        Console.WriteLine("-------------");
        Notify(tweet);
    }

    public void RegisterObserver(IObserver observer)
    {
        _observerList.Add(observer);
    }

    public void Unregister(IObserver observer)
    {
        _observerList.Remove(observer);
    }

    public void Notify(string tweet)
    {
        foreach (var item in _observerList)
        {
            item.Update(Name, tweet);
        }
    }
    }

    public class ConcreateClassA : IObserver
    {
         private string Name {get;set;}
         public ConcreateClassA(string name)
         {
            Name = name;
         }

         public void Update(string celebratyName, string tweet)
         {
            Console.WriteLine($"{Name} received{tweet} from {celebratyName}");
         }
    }

    public class ConcreateClassB : IObserver
    {
         private string Name {get;set;}

         public ConcreateClassB(string name)
         {
            Name = name;
         }
          public void Update(string celebratyName, string tweet)
         {
            Console.WriteLine($"{Name} received{tweet} from {celebratyName}");
         }

    }
}