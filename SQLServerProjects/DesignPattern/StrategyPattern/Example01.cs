namespace DesignPattern.StrategyPattern
{
    public interface Flybehavior
    {
        void Fly();
    }

    public class NoFly:Flybehavior
    {
        public void Fly()
        {
            Console.WriteLine("Dont flied.");
        }
    }

    public class FlyByWings:Flybehavior
    {
         public void Fly()
        {
            Console.WriteLine("flied by wings.");
            
        }
    }

    public class FlyByMotors:Flybehavior
    {
         public void Fly()
        {
            Console.WriteLine("flied by motors.");
            
        }
    }

    public  class Bird
    {
        private Flybehavior _flybehavior;

        public Bird(Flybehavior fly){
            _flybehavior = fly;
        }

        public void SetFlyStrategy(Flybehavior fly)
        {
            _flybehavior = fly;
        }

        public void performFly()
        {
            _flybehavior.Fly();
        }
    }


    
    
}