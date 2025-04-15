namespace Patterns.MediatorPattern.CheckForm
{
    public interface IMediator
    {
        void Notify(object sender, string ev);
    }
}