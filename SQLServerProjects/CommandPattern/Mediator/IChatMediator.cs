namespace CommandPattern.Mediator
{
    public interface IChatMediator
    {
        void SendMessage(string message, User sender);
        void AddUser(User user);
    }

    public class ChatServer : IChatMediator
    {
        private readonly List<User> _users = new List<User>();
       
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void SendMessage(string message, User sender)
        {
            Console.WriteLine($"Chat Server: Broadcasting message from {sender.Name}: {message}");
            foreach (var user in _users)
            {
                if (user != sender)
                {
                    user.ReceiveMessage(message, sender.Name);
                }
            }
        }
    }

    public class User
    {
        public string Name;
        private IChatMediator _chatMediator;
        public User(string name, IChatMediator chatMediator)
        {
            Name = name;
            _chatMediator = chatMediator;
        }

        public void SendMessage(string message)
        {
            _chatMediator.SendMessage(message, this);
        }
        public void ReceiveMessage(string message, string senderName)
    {
        Console.WriteLine($"{Name} received from {senderName}: {message}");
    }
    }
}