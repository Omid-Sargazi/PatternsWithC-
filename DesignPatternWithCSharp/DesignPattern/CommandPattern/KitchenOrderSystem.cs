namespace DesignPattern.CommandPattern
{
    public interface ICommandRobot
    {
        void Execute();
    }

    public class CookCommand : ICommandRobot
    {
        protected RobotChef _chef;

        public CookCommand(RobotChef chef)
        {
            _chef = chef;
        }

        public void Execute()
        {
            _chef.Cook();
        }
    }

    public class WashCommand : ICommandRobot
    {
        protected RobotChef _chef;
        public WashCommand(RobotChef chef)
        {
            _chef = chef;
        }
        public void Execute()
        {
            _chef.Wash();
        }
    }

    public class CleanCommand : ICommandRobot
    {
        protected RobotChef _chef;
        public CleanCommand(RobotChef chef)
        {
            _chef = chef;
        }
        public void Execute()
        {
            _chef.Clean();
        }
    }

    public class RobotChef
    {
        public void Cook() => Console.WriteLine("Cooking....");
        public void Wash() => Console.WriteLine("Washing dishes....");
        public void Clean() => Console.WriteLine("Cleaning floor....");
    }

    public class CommandInvoker
    {
        private ICommandRobot _commandRobot;
        public void SetComamnd(ICommandRobot commandRobot)
        {
            _commandRobot = commandRobot;
        }

        public void ExecuteCommand()
        {
            _commandRobot.Execute();
        }
    }

    public class QueueInvoker
    {
        private Queue<ICommandRobot> _commandQueue = new();

        public void AddCommand(ICommandRobot commandRobot)
        {
            _commandQueue.Enqueue(commandRobot);
        }

        public void Run()
        {
            while (_commandQueue.Count > 0)
            {
                var cmd = _commandQueue.Dequeue();
                cmd.Execute();
            }
        }
    }
}