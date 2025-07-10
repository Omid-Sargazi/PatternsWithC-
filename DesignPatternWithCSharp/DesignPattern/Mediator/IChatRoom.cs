using System.Threading.Tasks.Dataflow;

namespace DesignPattern.Mediator
{
    public interface IChatRoom
    {
        void Register(IUser user);
        void SendMessage(string message, IUser sender, IUser recipient);
    }

    public interface IUser
    {
        string Name { get; set; }
        void SendMessage(string message, IUser recipient);
        void ReciveMessage(string message, IUser sender);
    }

    public class ChatRoom : IChatRoom
    {
        private readonly List<IUser> _users = new List<IUser>();
        public void Register(IUser user)
        {
            _users.Add(user);
        }

        public void SendMessage(string message, IUser sender, IUser recipient)
        {
            foreach (var user in _users)
            {
                if (user != this)
                {
                    recipient.ReciveMessage(message, sender);
                }
            }
        }
    }

    public class User : IUser
    {
        private readonly IChatRoom _chatRoom;
        public string Name { get; set; }
        public User(string name, IChatRoom chatRoom)
        {
            Name = name;
            _chatRoom = chatRoom;
            _chatRoom.Register(this);
        }

        public void ReciveMessage(string message, IUser sender)
        {
            Console.WriteLine($"{Name} recieved {message} from {sender}");
        }

        public void SendMessage(string message, IUser recipient)
        {
            _chatRoom.SendMessage(message, this, recipient);
        }
    }
}