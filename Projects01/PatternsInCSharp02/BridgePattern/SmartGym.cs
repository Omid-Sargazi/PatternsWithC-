namespace PatternsInCSharp02.BridgePattern
{
    public interface IConnectionProtocol
    {
        void Connect();
        void DisConnect();
        void SendCommnad(string command);
    }

    public class BluetoothProtocol : IConnectionProtocol
    {
        public void Connect()
        {
            Console.WriteLine("Connected via Bluetooth");
        }

        public void DisConnect()
        {
            Console.WriteLine("Disconnected from Bluetooth");
        }

        public void SendCommnad(string command)
        {
            Console.WriteLine("Sending command via Bluetooth: " + command);
        }
    }

    public class WifiProtocol : IConnectionProtocol
    {
        public void Connect()
        {
            Console.WriteLine("Connected via Wifi");
        }

        public void DisConnect()
        {
            Console.WriteLine("Disconnected from Wifi");
        }

        public void SendCommnad(string command)
        {
            Console.WriteLine("Sending command via Wifi: " + command);
        }
    }

    public abstract class FitnessEquipment
    {
        protected IConnectionProtocol _connectionProtocol;
        protected string Name {get; set;}
        public FitnessEquipment(IConnectionProtocol connectionProtocol, string name)
        {
            _connectionProtocol = connectionProtocol;
            Name = name;
        }

        public abstract void Start();
        public abstract void Stop();
        public abstract void SetDifficulty(int level);

    }

    public class Treadmill : FitnessEquipment
    {
        public Treadmill(IConnectionProtocol connectionProtocol, string name) : base(connectionProtocol, name)
        {
        }

        public override void SetDifficulty(int level)
        {
            _connectionProtocol.SendCommnad($"set spead level{level}");
            Console.WriteLine($"set spead of tredmil on{level}");
        }

        public override void Start()
        {
            _connectionProtocol.Connect();
            _connectionProtocol.SendCommnad($"Stat tredmil{Name}");
            Console.WriteLine($"Treadmill {Name} started.");
        }

        public override void Stop()
        {
            _connectionProtocol.SendCommnad($"Stop tredmil{Name}");
            Console.WriteLine($"Tredmil {Name} stopped.");
            _connectionProtocol.DisConnect();

        }
    }

    public class ExerciseBike : FitnessEquipment
    {
        public ExerciseBike(IConnectionProtocol connectionProtocol, string name) : base(connectionProtocol, name)
        {
        }

        public override void SetDifficulty(int level)
        {
            _connectionProtocol.SendCommnad($"set resistance level{level}");
        }

        public override void Start()
        {
            _connectionProtocol.Connect();
        }

        public override void Stop()
        {
            _connectionProtocol.DisConnect();
        }
    }
}