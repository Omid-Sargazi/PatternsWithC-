namespace DesignPattern.CommandPattern
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class Light
    {
        public void On() => Console.WriteLine("Light turned ON.");
        public void Off() => Console.WriteLine("Light turned OFF.");
    }

    public class LighOnCommand : ICommand
    {
        private readonly Light _light;
        public LighOnCommand(Light light)
        {
            _light = light;
        }
        public void Execute()
        {
            _light.On();
        }

        public void Undo()
        {
            _light.Off();
        }
    }

    public class LightOffCommand : ICommand
    {
        private readonly Light _light;
        public LightOffCommand(Light light)
        {
            _light = light;
        }
        public void Execute()
        {
            _light.Off();
        }

        public void Undo()
        {
            _light.On();
        }
    }

    public class RemoteControl
    {
        private ICommand _slot;
        private ICommand _lastSlot;

        public void SetCommand(ICommand command)
        {
            _slot = command;
        }

        public void PessButton()
        {
            _slot.Execute();
            _lastSlot = _slot;
        }

        public void PressUndo()
        {
            _lastSlot?.Undo();
        }
    }
}