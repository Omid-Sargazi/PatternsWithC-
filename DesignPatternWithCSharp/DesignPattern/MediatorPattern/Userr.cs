namespace DesignPattern.MediatorPattern
{
    public class Userr
    {
        public string Name {get; set;}
        public List<Userr> Contacts = new();

        public Userr(string name)
        {
            Name = name;
        }

        public void Send(string message)
        {
            foreach (var user in Contacts)
            {
                user.Receive(message,this);
            }
        }

        public void Receive(string message, Userr sender)
        {
            Console.WriteLine($"{Name} received message from {sender.Name}: {message}");
        }
    }
}