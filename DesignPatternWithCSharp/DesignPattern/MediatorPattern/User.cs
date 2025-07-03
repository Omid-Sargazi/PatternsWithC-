namespace DesignPattern.MediatorPattern
{
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