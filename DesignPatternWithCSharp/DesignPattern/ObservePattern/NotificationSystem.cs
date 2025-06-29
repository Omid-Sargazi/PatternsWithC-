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
}