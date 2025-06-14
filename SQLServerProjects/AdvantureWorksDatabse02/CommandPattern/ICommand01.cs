namespace AdvantureWorksDatabse02.CommandPattern
{
    public class Light
    {
        public void TurnOn()=>Console.WriteLine();
        public void TurnOff()=>Console.WriteLine();
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
}
