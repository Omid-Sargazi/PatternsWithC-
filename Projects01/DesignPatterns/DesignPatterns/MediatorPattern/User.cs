namespace DesignPatterns.MediatorPattern
{
    public interface IChatRoom
    {
        void RegisterUser(User user);
        void SendMessage(string message, User user);
    }
    public class User
    {
        private string _name;
        private List<User> _users;
        public User(string name)
        {
            _name = name;
        }

        public void AddContact(User user)
        {
            _users.Add(user);
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"{_name} sends: {message}");
            foreach (var user in _users)
            {
                user.ReceiveMessage(message, _name);
            }
        }

        private void ReceiveMessage(string message, string sender)
        {
            Console.WriteLine($"{_name} received from {sender}:{message}");
        }
    }
}