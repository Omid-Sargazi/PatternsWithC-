namespace Patterns.MediatorPattern.Controllers
{
    public interface IMediator
    {
        void Notify(object sender, string eventName);
    }
}
