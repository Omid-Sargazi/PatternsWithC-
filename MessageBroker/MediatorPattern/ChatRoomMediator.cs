namespace MessageBroker.MediatorPattern
{
    public class ChatRoomMediator : IChatRoomMediator
    {
        private readonly Dictionary<string, User> _users = new();
        public void Register(User user)
        {
            if(!_users.ContainsKey(user.Name))
            {
                _users[user.Name] = user;
                user.Room = this;
            }
        }

        public void SendMessage(string from, string to, string message)
        {
           if (to == null)
            {
                // broadcast
                foreach (var u in _users.Values.Where(u => u.Name != from))
                    u.Receive($"{from}: {message}");
            }
            else if (_users.TryGetValue(to, out var recipient))
            {
                // private message
                recipient.Receive($"(private) {from}: {message}");
            }
        }
    }

}