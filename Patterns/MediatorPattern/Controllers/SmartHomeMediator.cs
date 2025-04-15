namespace Patterns.MediatorPattern.Controllers
{
    public class SmartHomeMediator : IMediator
    {
        private Light _light;
        private Thermostat _thermostat;
        private SecurityDoor _securityDoor;
        public SmartHomeMediator(Light light, Thermostat thermostat, SecurityDoor securityDoor)
        {
            _light = light;
            _securityDoor = securityDoor;
            _thermostat = thermostat;
        }
        public void Notify(object sender, string eventName)
        {
            if(eventName == "LightTurnedOn" && sender == _light)
            {
                _thermostat.AdjustTemperature();
                _securityDoor.Lock();
            }
            else if(eventName == "LightTurnedOff" && sender == _light)
            {
                _securityDoor.Unlock();
            }
            else if(eventName == "TemperatureAdjusted" && sender == _thermostat)
            {
                _light.TurnOff();
                _securityDoor.Unlock();
            }
            else if(eventName == "DoorLocked" && sender==_securityDoor)
            {
                _light.TurnOn();
            }
            else if(eventName == "DoorUnlocked" && sender == _securityDoor)
            {
                _thermostat.AdjustTemperature();
            }
        }
    }
}