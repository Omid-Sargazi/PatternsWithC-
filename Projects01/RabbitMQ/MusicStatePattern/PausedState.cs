namespace RabbitMQ.MusicStatePattern
{
    public class PausedState : IMusicPlayerState
    {
        public string GetStateName()
        {
            throw new NotImplementedException();
        }

        public void PressLock(MusicPalyer player)
        {
            throw new NotImplementedException();
        }

        public void PressPause(MusicPalyer player)
        {
            throw new NotImplementedException();
        }

        public void PressPlay(MusicPalyer player)
        {
            throw new NotImplementedException();
        }

        public void PressPower(MusicPalyer player)
        {
            throw new NotImplementedException();
        }
    }
}