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
}