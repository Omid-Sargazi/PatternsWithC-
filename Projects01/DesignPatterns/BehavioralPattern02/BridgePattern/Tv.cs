namespace BehavioralPattern02.BridgePattern
{
    public class Tv
    {
        public void TurnOn()=>Console.WriteLine("TV is ON");
        public void TurnOff() => Console.WriteLine("TV is Off");
    }

    public class Remote
    {
        private Tv _tv;
        public Remote(Tv tv)
        {
            _tv = tv;
        }

        public void TogglePower()
        {
             Console.WriteLine("Using Remote to toggle power.");
            _tv.TurnOn();
        }
    }
}