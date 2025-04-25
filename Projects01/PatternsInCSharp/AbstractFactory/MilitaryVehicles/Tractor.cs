namespace  PatternsInCSharp.AbstractFactory.MilitaryVehicles
{
    public class Tractor : ITank
    {
        public string GetModel()
        {
            return "John Deere";
        }
    }
}