namespace Patterns.MediatorPattern.Controllers
{
    public class SecurityDoor : BaseComponent
    {
        public SecurityDoor(IMediator mediator) : base(mediator)
        {
        }
        public void Lock()
    {
            Console.WriteLine("SecurityDoor locked");
            _mediator?.Notify(this, "DoorLocked");
        }

        public void Unlock()
        {
            Console.WriteLine("SecurityDoor unlocked");
            _mediator?.Notify(this, "DoorUnlocked");
        }
    }
}