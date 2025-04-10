namespace CompositePattern.FacadePattern
{
    public class MovieWatcher
    {
        public void WatchMovie()
        {
            var tv = new TV();
            var dvd = new DVDPlayer();
            var sound = new SoundSystem();

            tv.TurnOn();
            tv.SetInput("DVD");
            dvd.TurnOn();
            dvd.Play();
            sound.TurnOn();
            sound.SetVolume(10);
        }
    }
}