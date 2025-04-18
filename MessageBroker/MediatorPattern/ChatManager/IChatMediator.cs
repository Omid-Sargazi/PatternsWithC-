namespace MessageBroker.MediatorPattern.ChatManager
{
    public interface IChatMediator
    {
        void Register(IUser user);
        void Notify(object sender, string message);     
    }
}