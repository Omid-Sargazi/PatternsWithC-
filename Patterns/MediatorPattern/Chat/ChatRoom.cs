namespace Patterns.MediatorPattern.Chat
{
    public class ChatRoom : IMediator
    {
        private ComponentA _componentA;
        private ComponentB _componentB;
        public ChatRoom(ComponentA componentA, ComponentB componentB)
        {
            _componentA = componentA;
            _componentB = componentB;
            _componentA.SetMediator(this);
            _componentB.SetMediator(this);
        }
        
        public void Notify(object sender, string message)
        {
            if(sender == _componentA)
            {
                _componentB.ReceiveMessage(message);
            }
            else if(sender == _componentB)
            {
                _componentA.ReceiveMessage(message);
            }
        }
    }
}