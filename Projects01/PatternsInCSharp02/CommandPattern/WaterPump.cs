using System.Net.NetworkInformation;

namespace PatternsInCSharp02.CommandPattern
{
    public class WaterPump
    {
        public void TurnOn()=>Console.WriteLine("Turn on Pump");
        public void TurnOff()=>Console.WriteLine("Turn off Pump");
    }

    public class GrowLight
    {
        public void TurnOn()=> Console.WriteLine("Turn On Light");
        public void TurnOff()=> Console.WriteLine("Turn Off Light");
    }

    public class GreenhouseController
    {
        private readonly WaterPump _waterPump;
        private readonly GrowLight _growLight;
        public GreenhouseController(WaterPump waterPump, GrowLight growLight)
        {
            _waterPump = waterPump;
            _growLight = growLight;
        }
        

        public void ExecuteCommand(string command)
        {
            switch(command)
            {
                case "PumpOn":
                    _waterPump.TurnOn();
                    break;
                case "PumpOff":
                    _waterPump.TurnOff();
                    break;
                case "LightOn":
                    _growLight.TurnOn();
                    break;
                case "LightOff":
                    _growLight.TurnOff();
                    break;

                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}