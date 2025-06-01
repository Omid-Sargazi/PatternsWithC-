namespace AdventureWorksLT2019_2.PatternsInCSharp
{
    public interface ICommandLight
    {
        public void Run();
        public void Undo();
    }
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine($"Light is on.");
        }

        public void TurnOff()
        {
            Console.WriteLine($"Light is Off.");
        }
    }

    public class TurnOnLight : ICommandLight
    {
        private Light _light;
        public TurnOnLight(Light light)
        {
            _light = light;
        }
        public void Run()
        {
            _light.TurnOn();
        }

        public void Undo()
        {
            _light.TurnOff();
        }
    }

    

    public class Control
    {
        private TurnOnLight _turnOnLight;
        public Control(TurnOnLight turnOnLight)
        {
            _turnOnLight = turnOnLight;
        }
        

        public void Remote()
        {
            _turnOnLight.Run();
        }

        public void Undo()
        {
            _turnOnLight.Undo();
        }
    }
}