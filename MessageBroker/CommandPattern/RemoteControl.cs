namespace MessageBroker.CommandPattern
{
    public class RemoteControl 
    {
        private ICommand _command;
        public RemoteControl(ICommand command)
        {
            _command = command;
        }

        public void PressButton()
        {
            _command.Execute();
        }
    }
}