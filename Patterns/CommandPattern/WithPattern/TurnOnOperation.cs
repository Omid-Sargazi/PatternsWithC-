using Patterns.CommandPattern.WithoutPattern;

namespace Patterns.CommandPattern.WithPattern
{
    public class TurnOnOperation : IOperation
    {
        private Television _tv;
        public TurnOnOperation(Television tv)
        {
            _tv = tv;
        }
        public void Execute()
        {
            _tv.TurnOn();   
        }
    }
}