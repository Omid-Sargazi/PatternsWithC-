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
        public List<User> Contacts = new();
        public User(string name)
        {
            Name = name;
        }

        public void SendMessage(string message, User receiver)
        {
            Console.WriteLine($"{Name} sends message to {receiver.Name}: {message}");
            receiver.ReceiveMessage(message, this);

        }

        public void ReceiveMessage(string message, User sender)
        {
            Console.WriteLine($"{Name} received from {sender.Name}: {message}");
        }
    }
}