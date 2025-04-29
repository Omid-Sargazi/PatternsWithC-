namespace PatternsInCSharp02.CommandPattern
{
    public class Lights
    {
        public void TurnOn()=>Console.WriteLine("Turn On Light");
        public void TurnOff()=>Console.WriteLine("Turn Off Light");
    }

    public class thermostat
    {
        public void InceaseTemp()=>Console.WriteLine("Increase Temperature");
        public void DecreaseTemp()=>Console.WriteLine("Decreaase Temperature");
    }
}