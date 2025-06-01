namespace AdventureWorksLT2019_2.PatternsInCSharp
{
    
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


    public class Client
    {
        private Light _light;
        public Client(Light light)
        {
            _light = light;
        }

        public void Remote()
        {
            _light.TurnOn();
        }

        public void Undo()
        {
            _light.TurnOff();
        }
    }
}