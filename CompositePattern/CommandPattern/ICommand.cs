namespace CompositePattern.CommandPattern
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}