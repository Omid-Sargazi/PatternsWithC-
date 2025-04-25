namespace  PatternsInCSharp.AbstractFactory.MilitaryVehicles
{
    public class PassengerPlane : IAirplane
    {
        public string GetName()
        {
            return "Boeing 737";
        }
    }
}