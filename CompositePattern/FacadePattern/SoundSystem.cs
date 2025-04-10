namespace CompositePattern.FacadePattern
{
    public class SoundSystem
    {
       public void TurnOn() => Console.WriteLine("Sound System is on");
        public void SetVolume(int level) => Console.WriteLine($"Volume set to {level}");
    }
}