namespace CommandPattern.MediatorPattern
{
    public interface IChatRoom
    {
        void RegisterUser(User user);
        void SendMessage(string message, User sender);
    }

    public class ChatRoom : IChatRoom
    {
        private List<User> _users = new List<User>();
        public void RegisterUser(User user)
        {
            _users.Add(user);
            Console.WriteLine($"{user.Name} joined the chat room.");
        }

        public void SendMessage(string message, User sender)
        {
            foreach (var user in _users)
            {
                if (user != sender)
                {
                    user.ReceiveMessage(message, sender);
                }
            }
        }
    }

    public class User
    {
        public string Name { get; set; }
        private IChatRoom _chatRoom;
        public User(string name, IChatRoom chatRoom)
        {
            Name = name;
            _chatRoom = chatRoom;
        }
        

        public void SendMessage(string message)
        {
            Console.WriteLine($"{Name} sends:{message}");
            _chatRoom.SendMessage(message, this);
        }

        public void ReceiveMessage(string message, User user)
        {
            Console.WriteLine($"{Name} received from {user.Name}:{message}");
        }
    }
}