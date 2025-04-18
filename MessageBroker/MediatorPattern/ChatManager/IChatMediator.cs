namespace MessageBroker.MediatorPattern.ChatManager
{
    public interface IChatMediator
    {
        void Notify(object sender, string message);     
    }
}