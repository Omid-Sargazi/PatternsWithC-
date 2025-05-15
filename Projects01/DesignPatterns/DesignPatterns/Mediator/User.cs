namespace DesignPatterns.Mediator
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
            Console.WriteLine($"{sender.Name} sends: {message}");
            foreach(var user in _users)
            {
                if(user != sender)
                {
                    user.ReceiveMessage(message, sender.Name);
                }
            }
        }
    }

    public class User
    {
        private IChatRoom _chatRoom;
        private string _name;
        public string Name =>_name;

        public void SetChatRoom(IChatRoom chatRoom)
        {
            _chatRoom = chatRoom;
        }
        
        public User(string name)
        {
            _name = name;
        }

        

        public void SendMessage(string message)
        {
           _chatRoom.SendMessage(message,this);
        }
        public void ReceiveMessage(string message, string sender)
        {
            Console.WriteLine($"{_name} received from {sender}: {message}");
        }
    }
}