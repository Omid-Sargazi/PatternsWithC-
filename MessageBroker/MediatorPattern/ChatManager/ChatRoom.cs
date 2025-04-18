namespace MessageBroker.MediatorPattern.ChatManager
{
    public class ChatRoom : IChatMediator
    {
        private List<IUser> _users = new();
        
        
        public ChatRoom(List<IUser> users)
        {
            _users = users;
        }
        public void Notify(object sender, string message)
        {
           foreach(var user in _users)
           {
                if(user !=sender)
                {
                    user.ReceiveMessage(message);
                }
           }
        }

        public void Register(IUser user)
        {
            _users.Add(user);
        }
    }
}