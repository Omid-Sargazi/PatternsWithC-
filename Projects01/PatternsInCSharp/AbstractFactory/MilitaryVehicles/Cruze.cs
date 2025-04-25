namespace PatternsInCSharp.AbstractFactory.MilitaryVehicles
{
    public class Cruze : IShip
    {
        string IShip.GetType()
        {
            return "Royal Caribbean";
        }
    }
}