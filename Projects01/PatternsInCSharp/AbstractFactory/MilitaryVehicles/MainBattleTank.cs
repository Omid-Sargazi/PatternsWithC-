namespace PatternsInCSharp.AbstractFactory.MilitaryVehicles
{
    public class MainBattleTank : ITank
    {
        public string GetModel()
        {
            return "M1 Abrams";
        }
    }
}