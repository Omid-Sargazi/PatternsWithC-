namespace PatternsInCSharp.AbstractFactory.MilitaryVehicles
{
    public class Dastroyer : IShip
    {
        string IShip.GetType()
        {
            return "Zumwalt";
        }
    }
}