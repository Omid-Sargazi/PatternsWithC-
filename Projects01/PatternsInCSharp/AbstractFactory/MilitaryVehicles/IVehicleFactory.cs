namespace PatternsInCSharp.AbstractFactory.MilitaryVehicles
{
    public interface IVehicleFactory
    {
        IAirplane CreateAirPlain();
        ITank CreateTank();
        IShip CreateShip();
    }

    public class MilitaryVehicleFactory : IVehicleFactory
    {
        public IAirplane CreateAirPlain()
        {
            return new FighterJet();
        }

        public IShip CreateShip()
        {
            return new Dastroyer();
        }

        public ITank CreateTank()
        {
            return new MainBattleTank();
        }
    }

    public class CivilianVehicleFactory : IVehicleFactory
    {
        public IAirplane CreateAirPlain()
        {
            return new PassengerPlane();
        }

        public IShip CreateShip()
        {
            return new Cruze();
        }

        public ITank CreateTank()
        {
            return new Tractor();
        }
    }
}