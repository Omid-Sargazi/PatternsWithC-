namespace RabbitMQ.MusicStatePattern
{
    public class OffState : IMusicPlayerState
    {
        private IMusicPlayerState _state;
        public OffState()
        {

            _state = new OffState();
        }

        public string GetStateName()
        {
            return "Off";
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
            Console.WriteLine("دستگاه روشن شد و در حالت آماده قرار گرفت");
            player.SetState(new ReadyState());
        }

        public void PressPower(MusicPalyer player)
        {
            throw new NotImplementedException();
        }
    }
}