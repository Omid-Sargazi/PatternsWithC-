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

    public class Client
    {
        public void ShowVehicles(IVehicleFactory factory)
        {
            var airplane = factory.CreateAirPlain();
            var tank = factory.CreateTank();
            var ship = factory.CreateShip();
             Console.WriteLine($"نمایش محصولات:\n✈️ {airplane.GetName()}\n⚙️ {tank.GetModel()}\n🚢 {ship.GetType()}");
        }
    }
}