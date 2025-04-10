namespace CompositePattern.FacadePattern
{
    public class HomeTheater
    {
        private TV _tv;
        private DVDPlayer _dVDPlayer;
        private SoundSystem _soundSystem;
        public HomeTheater(TV tV, DVDPlayer dVDPlayer, SoundSystem soundSystem)
        {
            _tv = tV;
            _soundSystem = soundSystem;
            _dVDPlayer = dVDPlayer;
        }

        public void WatchMovie()
        {
            _tv.TurnOn();
            _tv.SetInput("DVD");
            _dVDPlayer.TurnOn();
            _dVDPlayer.Play();
            _soundSystem.TurnOn();
            _soundSystem.SetVolume(10);
        }

        public void TurnOff()
        {
            _dVDPlayer.TurnOn();
            _tv.TurnOn();
            _soundSystem.TurnOn();
        }
    }
}