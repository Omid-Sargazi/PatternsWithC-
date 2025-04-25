namespace PatternsInCSharp.FactoryPattern
{
    public class FactoryCar
    {
        public IBuild GetCar(string carType)
        {
            if(carType == "Benz")
            {
                return new BenzBuild();
            }
            else if(carType == "BMW")
            {
                return new BMWBuild();
            }
            else
            {
                throw new Exception("Car type not found");
            }
        }
    }
}