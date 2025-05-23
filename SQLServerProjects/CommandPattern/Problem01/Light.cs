namespace CommandPattern.Problem01
{
    public interface ICommandControllerLight
    {
        void Execute();
        void Undo();
    }
    public class Light
    {
        public void TurnOn() => Console.WriteLine($"Light is On");
        public void TurnOff() => Console.WriteLine($"Light is Off");
    }

    public class LightOnCommand : ICommandControllerLight
    {
        private Light _light;
        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }

        public void Undo()
        {
            _light.TurnOff();
        }
    }

    public class LightOffCommand : ICommandControllerLight
    {
        private Light _light;
        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }

        public void Undo()
        {
            _light.TurnOn();
        }
    }

    public class RemoteControll
    {
        private ICommandControllerLight _command;
        private Light _light;
        public RemoteControll(ICommandControllerLight command)
        {
            _command = command;
        }

        public void PressButton(string action)
        {
            _command.Execute();
        }
        public void PressUndo()
        {
            _command.Undo();
        }
    }
}