namespace AdventureWorksLT2019_2.MediatorPattern
{
    public interface IChatRoomMediator
    {
        void SendMessage(string message, User user);
    }

    public class ChatrRoom : IChatRoomMediator
    {
        private List<User> _users = new List<User>();
        public void RegisterUser(User user)
        {
            _users.Add(user);
            Console.WriteLine($"{user.Name} has joined the chat.");
        }
        public void SendMessage(string message, User sender)
        {
            foreach (var user in _users)
            {
                if (user != sender)
                {
                    user.Receive(message);
                }
            }
        }
    }

    public class User
    {
        private IChatRoomMediator _chatRoomMediator;
        public string Name { get; }

        public User(IChatRoomMediator chatRoomMediator, string name)
        {
            Name = name;
            _chatRoomMediator = chatRoomMediator;
        }

        public void Send(string message)
        {
            Console.WriteLine($"{Name} sends: {message}");
            _chatRoomMediator.SendMessage(message, this);
        }

        public void Receive(string message)
        {
            Console.WriteLine($"{Name} received: {message}");
        }

    }
}