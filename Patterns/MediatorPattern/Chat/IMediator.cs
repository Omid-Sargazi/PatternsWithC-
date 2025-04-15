namespace Patterns.MediatorPattern.Chat
{
    public interface IMediator
    {
        void Notify(object sender, string message);
    }
}