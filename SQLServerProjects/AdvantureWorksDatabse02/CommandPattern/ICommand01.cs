namespace AdvantureWorksDatabse02.CommandPattern
{
    public class Light
    {
        public void TurnOn() => Console.WriteLine();
        public void TurnOff() => Console.WriteLine();
    }

    public class RemoteControl
    {
        private Light _light;
        public RemoteControl(Light light)
        {
            _light = light;
        }

        public void PressOnButton()
        {
            _light.TurnOn();
        }

        public void PressOffButton()
        {
            _light.TurnOff();
        }
    }

    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class LightOnCommand : ICommand
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

    public class LightOffCommand : ICommand
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
}
