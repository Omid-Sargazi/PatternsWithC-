namespace DesignPatterns.Facade
{
    public class DvdPlayer
    {
        public void TurnOn()=>Console.WriteLine("DVD Player turned on.");
        public void Play()=>Console.WriteLine("DVD Player is playing.");
    }

    public class Projector
    {
        public void TurnOn()=>Console.WriteLine("projector turned on");
        public void SetInput()=>Console.WriteLine("projector seted input");
    }

    public class SoundSystem
    {
        public void TurnOn()=>Console.WriteLine("Sound System turned on.");
        public void SetVolume()=>Console.WriteLine("Sound System seted volume");
    }
    public class HomeTheaterFacade
    {
        private readonly DvdPlayer _dvdPlayer;
        private readonly Projector _projector;
        private readonly SoundSystem _soundSystem;
        public HomeTheaterFacade(DvdPlayer dvdPlayer, Projector projector, SoundSystem soundSystem)
        {
            _dvdPlayer = dvdPlayer;
            _projector = projector;
            _soundSystem = soundSystem;
        }

        public void WatchMovie()
        {
            Console.WriteLine("Prepering for wathing movie");
            _dvdPlayer.TurnOn();
            _projector.TurnOn();
            _projector.SetInput();
            _soundSystem.TurnOn();
            _soundSystem.SetVolume();
            _dvdPlayer.Play();
            Console.WriteLine("enjoy form watching movie");
        }
    }
}