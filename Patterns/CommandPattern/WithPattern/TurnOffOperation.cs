using Patterns.CommandPattern.WithoutPattern;

namespace Patterns.CommandPattern.WithPattern
{
    public class TurnOffOperation : IOperation
    {
        private Television _tv;
        public TurnOffOperation(Television tv)
        {
            _tv = tv;
        }
        public void Execute()
        {
            _tv.TurnOff();
        }
    }
}