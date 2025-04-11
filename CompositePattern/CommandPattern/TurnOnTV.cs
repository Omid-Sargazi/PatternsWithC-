namespace CompositePattern.CommandPattern
{
    public class TurnOnTV : ICommand
    {
        private TV _tv;
        public TurnOnTV(TV tV)
        {
            _tv = tV;
        }
        public void Execute()
        {
            _tv.TurnOn();
        }

        public void Undo()
        {
            _tv.TurnOff();
        }
    }
}