namespace CompositePattern.CommandPattern.Order
{
    public interface ICommand
    {
        void Execute();
        // void Undo();
        bool CanExcecute();
    }
}