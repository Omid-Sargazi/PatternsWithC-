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

    public class RemoteControll
    {
        private Light _light;
        public RemoteControll(Light light)
        {
            _light = light;
        }

        public void PressButton(string action)
        {
            if (action == "ON")
            {
                _light.TurnOn();
            }
            else if (action == "OFF")
            {
                _light.TurnOff();
            }
        }
    }
}