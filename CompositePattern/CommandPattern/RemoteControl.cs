namespace CompositePattern.CommandPattern
{
    public class RemoteControl
    {
        private ICommand _command;
        private Stack<ICommand> _history = new Stack<ICommand>();
        public RemoteControl(ICommand command)
        {
            _command = command;
        }
        //     private TV _tv;
        //     public RemoteControl(TV tv)
        //     {
        //         _tv = tv;
        //     }
        //     public void PressOnButton()
        //     {
        //         _tv.TurnOn();
        //     }
        //     public void PressOfButton()
        //     {
        //         _tv.TurnOff();
        //     }
        //     public void PressVolumeUpButton()
        //     {
        //         _tv.VolumeUp();
        //     }

        // public void PressVolumeDownButton()
        //     {
        //         _tv.VolumeDown();
        //     }
        public void SetCommand(ICommand command)
        {
            _command = command;
        }
        public void PressButton()
        {
            _command.Execute();
            _history.Push(_command);
        }
        public void PressUndo()
        {
            if(_history.Count>0)
            {
                var lastCommand = _history.Pop();
                lastCommand.Undo();
            }
        }
    }
}