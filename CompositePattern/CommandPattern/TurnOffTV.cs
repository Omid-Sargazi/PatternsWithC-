namespace CompositePattern.CommandPattern
{
    public class TurnOffTV : ICommand
    {
        private TV _tv;
        public TurnOffTV(TV tv)
        {
            _tv = tv;
        }
        public void Execute()
        {
            _tv.TurnOff();
        }

        public void Undo()
        {
            _tv.TurnOn();
        }
    }
}