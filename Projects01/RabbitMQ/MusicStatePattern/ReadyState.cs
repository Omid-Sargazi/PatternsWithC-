namespace RabbitMQ.MusicStatePattern
{
    public class ReadyState : IMusicPlayerState
    {
        public string GetStateName()
        {
            return "Ready";
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
            Console.WriteLine("در حال پخش موسیقی...");
            player.SetState(new PlayingState());
        }

        public void PressPower(MusicPalyer player)
        {
            Console.WriteLine("دستگاه خاموش شد");
            player.SetState(new OffState());
        }
    }
}