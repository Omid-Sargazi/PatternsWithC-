namespace PatternsInCSharp.AbstractFactory.MilitaryVehicles
{
    public class FighterJet : IAirplane
    {
        public string GetName()
        {
            return "F-22 Raptor";
        }
    }
}