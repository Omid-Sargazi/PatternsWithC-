namespace PatternsInCSharp02.BridgePattern
{
    public interface ILightingProtocol
    {
        void SendBrightnessCommand(int zoneId, int brightness);
        void SendColorCommand(int zoneId, int color);
        void SendPowerCommand(int zoneId, bool powerOn);
    }

    public class DALIProtocol : ILightingProtocol
    {
        public void SendBrightnessCommand(int zoneId, int brightness)
        {
            throw new NotImplementedException();
        }

        public void SendColorCommand(int zoneId, int color)
        {
            throw new NotImplementedException();
        }

        public void SendPowerCommand(int zoneId, bool powerOn)
        {
            throw new NotImplementedException();
        }
    }

    public class KNXProtocol : ILightingProtocol
    {
        public void SendBrightnessCommand(int zoneId, int brightness)
        {
            throw new NotImplementedException();
        }

        public void SendColorCommand(int zoneId, int color)
        {
            throw new NotImplementedException();
        }

        public void SendPowerCommand(int zoneId, bool powerOn)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class LightingSystem
    {
        protected ILightingProtocol _protocol;
        public LightingSystem(ILightingProtocol protocol)
        {
            _protocol = protocol;
        }
        public abstract void SetBrightness(int zoneId, int brightness);
    }

    public class GeneralLighting : LightingSystem
    {
        public GeneralLighting(ILightingProtocol protocol) : base(protocol)
        {
        }

        public override void SetBrightness(int zoneId, int brightness)
        {
           _protocol.SendBrightnessCommand(zoneId, brightness);
        }
    }
}