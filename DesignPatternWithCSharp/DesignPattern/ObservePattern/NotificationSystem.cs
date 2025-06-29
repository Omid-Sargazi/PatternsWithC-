namespace DesignPattern.ObservePattern
{
    public interface IUserObserver
    {
        void OnUserRegister(string userName);
    }

    

    public class EmailNotifier : IUserObserver
    {
        public void OnUserRegister(string userName)
        {
            Console.WriteLine($"[Email] Welcome email sent to {userName}");
        }
    }

    public class AdminNotifier : IUserObserver
    {
        public void OnUserRegister(string userName)
        {
            Console.WriteLine($"[Admin Dashboard] Admin notified about {userName}");
        }
    }

    public class Loggerr : IUserObserver
    {
        public void OnUserRegister(string userName)
        {
            Console.WriteLine($"[Logger] User {userName} registered at {DateTime.Now}");
        }
    }

    public class UserService
    {
        private readonly List<IUserObserver> _userObservers = new List<IUserObserver>();
        public void Attach(IUserObserver observer) => _userObservers.Add(observer);
        public void Detach(IUserObserver observer) => _userObservers.Remove(observer);

        public void Registe(string userName)
        {
            Console.WriteLine($"User {userName} registered.");
            foreach (var observer in _userObservers)
            {
                observer.OnUserRegister(userName);
            }
        }
        
    }
}