namespace CompositePattern.CommandPattern
{
    public class RemoteControl
    {
        private TV _tv;
        public RemoteControl(TV tv)
        {
            _tv = tv;
        }
        public void PressOnButton()
        {
            _tv.TurnOn();
        }
        public void PressOfButton()
        {
            _tv.TurnOff();
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