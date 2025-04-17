namespace MessageBroker.MediatorPattern
{
    public class User
    {
       public string Name { get; set; }
       public IChatRoomMediator Room {get; set;}

       public void Send(string message)
       {
            Room.SendMessage(this.Name, null, message);
       }
       public void SendPrivate(string to, string message)
        {
            Room.SendMessage(this.Name, to, message);
        }

    public void Receive(string message)
        {
            Console.WriteLine($"{Name} received >> {message}");
        }
    }
}