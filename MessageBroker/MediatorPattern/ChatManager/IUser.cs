namespace MessageBroker.MediatorPattern.ChatManager
{
    public interface IUser
    {
        string Name {get;}
        void ReceiveMessage(string message);
    }
}