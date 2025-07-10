namespace DesignPattern.Mediator
{
    public interface IAirTrafficControl
    {
        void RegisterAircraft(IAircraft aircraft);
        void SendInstruction(string instruction, IAircraft sender, IAircraft recipient);
    }

    public interface IAircraft
    {
        string Id { get; }
        void SendInstruction(string instruction, IAircraft recipient);
        void ReceiveInstruction(string instruction, IAircraft sender);
    }

    public class AirTrafficControl : IAirTrafficControl
    {
        private readonly List<IAircraft> _aircraft = new();
        public void RegisterAircraft(IAircraft aircraft)
        {
            _aircraft.Add(aircraft);
        }

        public void SendInstruction(string instruction, IAircraft sender, IAircraft recipient)
        {
            recipient.ReceiveInstruction(instruction, sender);
        }
    }


    public class Aircraft : IAircraft
    {
        public string Id { get; }
        private readonly IAirTrafficControl _controlTower;

        public void ReceiveInstruction(string instruction, IAircraft sender)
        {
            Console.WriteLine($"{Id} recieved {instruction} from {sender.Id}");
        }

        public void SendInstruction(string instruction, IAircraft recipient)
        {
            _controlTower.SendInstruction(instruction, this, recipient);
        }
    }
}