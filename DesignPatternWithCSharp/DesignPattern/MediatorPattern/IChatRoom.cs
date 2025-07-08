using System.Net.NetworkInformation;

namespace DesignPattern.MediatorPattern
{
    public interface IChatRoomm
    {
        void SendMessage(string message, UserMediator user);
        void AddUser(UserMediator user);
    }

    public class ChatRoomm : IChatRoomm
    {
        private readonly List<UserMediator> _users = new List<UserMediator>();

        public void AddUser(UserMediator user)
        {
            _users.Add(user);
        }

        public void SendMessage(string message, UserMediator user)
        {
            foreach (var item in _users)
            {
                if (item != user)
                {
                    item.ReceiveMessage(message);
            }
           }
        }
    }

    public class UserMediator
    {
        private readonly IChatRoomm _chatRoomm;
        public string Name { get; set; }

        public UserMediator(string name, IChatRoomm chatRoom)
        {
            Name = name;
            _chatRoomm = chatRoom;
            _chatRoomm.AddUser(this);
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"{Name} sends {message}");
            _chatRoomm.SendMessage(message, this);
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"{Name} received : {message}");
        }
    }
}