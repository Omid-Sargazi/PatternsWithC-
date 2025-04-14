namespace Patterns.CommandPattern.WithPattern
{
    public class RemoteController 
    {
        private IOperation _onButtonOperation;
        private IOperation _offButtonOperation;
        public RemoteController(IOperation onOperation,IOperation offOperation)
        {
            _onButtonOperation = onOperation;
            _offButtonOperation = offOperation;
        }
        
        public void PressOnButton()
        {
            _onButtonOperation.Execute();
        }
        public void PressOffButton()
        {
            _offButtonOperation.Execute();
        }
    }
}