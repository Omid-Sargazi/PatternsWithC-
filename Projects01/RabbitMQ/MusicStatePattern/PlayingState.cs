namespace RabbitMQ.MusicStatePattern
{
    public class PlayingState : IMusicPlayerState
    {
        public string GetStateName()
        {
            return "Playing";
        }

        public void PressLock(MusicPalyer player)
        {
            Console.WriteLine("دستگاه قفل شد، اما پخش ادامه دارد");
             player.SetState(new LockedState());
        }

        public void PressPause(MusicPalyer player)
        {
            Console.WriteLine("پخش موسیقی متوقف شد");
            player.SetState(new PausedState());
        }

        public void PressPlay(MusicPalyer player)
        {
            Console.WriteLine("دستگاه در حال حاضر در حال پخش است");
        }

        public void PressPower(MusicPalyer player)
        {
            Console.WriteLine("پخش متوقف شد و دستگاه خاموش شد");
            player.SetState(new OffState());
        }
    }
}