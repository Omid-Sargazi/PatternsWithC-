namespace RabbitMQ.MusicStatePattern
{
    public interface IMusicPlayerState
    {
        public void PressPower(MusicPalyer player);
        public void PressPlay(MusicPalyer player);
        public void PressPause(MusicPalyer player);
        public void PressLock(MusicPalyer player);

        string GetStateName();
    }
}