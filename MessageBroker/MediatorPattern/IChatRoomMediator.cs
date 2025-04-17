namespace MessageBroker.MediatorPattern
{
    public interface IChatRoomMediator
    {
        void Register(User user);
        void SendMessage(string from, string to, string message);
    }
}