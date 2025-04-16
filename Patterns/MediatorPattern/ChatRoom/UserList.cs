namespace Patterns.MediatorPattern.ChatRoom
{
    public class UserList
    {
        private IChatMediator _mediator;
        public UserList(IChatMediator mediator)
        {
            _mediator = mediator;
        }

        public void SelectUse()
        {
            _mediator.Notify(this, "User selected");
        }
    }
}