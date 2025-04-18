namespace MessageBroker.MediatorPattern.ChatManager
{
    public class ChatRoom : IChatMediator
    {
        private UserA _userA;
        private UserB _userB;
        public ChatRoom(UserA userA, UserB userB)
        {
            _userA = userA;
            _userB = userB;
            _userB.SetMediator(this);
            _userA.SetMediator(this);
        }
        public void Notify(object sender, string message)
        {
            if(sender == _userA)
            {
                _userB.ReceiveMessage(message);
            }
            else if(sender == _userB)
            {
                _userA.ReceiveMessage(message);
            }
        }
    }
}