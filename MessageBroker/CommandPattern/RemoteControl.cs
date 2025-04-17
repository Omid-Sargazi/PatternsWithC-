namespace MessageBroker.CommandPattern
{
    public class RemoteControl 
    {
        private ICommand _command;
        private readonly Stack<ICommand> _history = new();
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
            if(_history.Count() == 0) return;
            var cmd = _history.Pop();
            cmd.Undo();
        }
    }
}