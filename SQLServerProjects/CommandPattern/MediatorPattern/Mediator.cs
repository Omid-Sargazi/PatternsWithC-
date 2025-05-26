namespace CommandPattern.MediatorPattern
{
    public interface IChatRoom
    {
        void RegisterUser(User user);
        void SendMessage(string message, User sender);
    }

    public class ChatRoom : IChatRoom
    {
        public void RegisterUser(User user)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message, User sender)
        {
            throw new NotImplementedException();
        }
    }

    public class User
    {
        public string Name { get; set; }
        private List<User> _contacts { get; set; } = new List<User>();
        public User(string name)
        {
            Name = name;
        }

        private void AddContect(User user)
        {
            _contacts.Add(user);
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"{Name} sends:{message}");
            foreach (var user in _contacts)
            {
                user.ReceiveMessage(user.Name, this);
            }
        }

        public void ReceiveMessage(string message, User user)
        {
            Console.WriteLine($"{Name} received from {user.Name}:{message}");
        }
    }
}