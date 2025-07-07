namespace DesignPattern.MediatorPattern
{
    public interface IChatRoomMediator
    {
        void Register(Userr user);
        void Send(string message, Userr user);
    }

    public class ChatRoomMediator : IChatRoomMediator
    {
        private List<Userr> _users = new();

       
        public void Register(Userr user)
        {
            _users.Add(user);
            
        }

        public void Send(string message, Userr user)
        {
            foreach (var item in _users)
            {
                if (item != user)
                {
                    item.Receive(message, user);
                }
            }
        }
    }
    public class Userr
    {
        public string Name {get; set;}
        private IChatRoomMediator _mediator;
        public Userr(IChatRoomMediator mediator)
        {
            _mediator = mediator;
        }


        public void SetMediator(IChatRoomMediator mediator)
        {
            _mediator = mediator;
        }

        public void Send(string message)
        {
            _mediator.Send(message, this);
        }


        public void Receive(string message, Userr sender)
        {
            Console.WriteLine($"{Name} received message from {sender.Name}: {message}");
        }
    }
}