namespace RabbitMQ.MusicStatePattern
{
    public class MusicPalyer
    {
        private IMusicPlayerState _state;
        public MusicPalyer()
        {
            _state = new OffState();
        }

        public void SetState(IMusicPlayerState state)
        {
            _state = state;
            Console.WriteLine($" حالت «{_state.GetStateName()}» تغییر کرد");
        }
        public void PressPower()
        {
            _state.PressPower(this);
        }
        public void PressPaly()
        {
            _state.PressPlay(this);
        }
        public void PressPause()
        {
            _state.PressPause(this);
        }
        public void PressLock()
        {
            _state.PressLock(this);
        }
    }
}