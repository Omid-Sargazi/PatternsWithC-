namespace DesignPattern.MediatorPattern
{

    public interface IChatRoom
    {
        void ShowMessage(string message, User sender, User receiver);
    }

    public class ChatRoom : IChatRoom
    {
        public void ShowMessage(string message, User sender, User receiver)
        {
            Console.WriteLine($"{sender.Name} to {receiver.Name}: {message}");
            receiver.ReceiveMessage(message, sender);
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

        public void SendMessage(string message, User receiver)
        {
            _chatRoom.ShowMessage(message, this, receiver);

        }

        public void ReceiveMessage(string message, User sender)
        {
            Console.WriteLine($"{Name} received from {sender.Name}: {message}");
        }
    }
}