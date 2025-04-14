namespace Patterns.CommandPattern.WithoutPattern
{
    public class RemoteControl
    {
        private Television _tv;
        public RemoteControl(Television tv)
        {
            _tv = tv;
        }
        public void PressOnButton()
        {
            _tv.TurnOn();
        }
        public void PressOffButton()
        {
            _tv.TurnOff();
        }
         public void PressChannelButton(int channel)
        {
            _tv.ChangeChannel(channel);
        }

        public void PressVolumeUpButton()
        {
            _tv.VolumeUp();
        }

        public void PressVolumeDownButton()
        {
            _tv.VolumeDown();
        }
    }
}