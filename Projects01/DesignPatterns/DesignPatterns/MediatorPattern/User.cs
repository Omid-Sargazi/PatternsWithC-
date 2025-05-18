namespace DesignPatterns.MediatorPattern
{
    public interface IChatRoom
    {
        void RegisterUser(User user);
        void SendMessage(string message, User user);
    }

    public class ChatRoom : IChatRoom
    {
        private List<User> _users;
        public ChatRoom(User user)
        {
            _users = new List<User>();
        }
        public void RegisterUser(User user)
        {
            _users.Add(user);
            user.SetChatRoom(this);
            Console.WriteLine($"{user._name} joined the chat room.");
        }

        public void SendMessage(string message, User sender)
        {
            Console.WriteLine($"{sender._name} sends: {message}");
            foreach (var user in _users)
            {
                if (user != sender)
                {
                    user.ReceiveMessage(message, sender._name);
                }
            }
        }
    }

    public class User
    {
        public string _name;
        public User(string name)
        {
            _name = name;
        }

        private IChatRoom _chatRoom;
        public User(IChatRoom chatRoom)
        {
            _chatRoom = chatRoom;
        }

        public void SetChatRoom(IChatRoom chatRoom)
        {
            _chatRoom = chatRoom;
        }
       

       

        public void SendMessage(string message)
        {
            _chatRoom.SendMessage(message,this);
        }

        public void ReceiveMessage(string message, string sender)
        {
            Console.WriteLine($"{_name} received from {sender}:{message}");
        }
    }
}