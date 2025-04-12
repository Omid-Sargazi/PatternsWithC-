namespace CompositePattern.CommandPattern
{
    public interface IDrawCommand
    {
        void Execute();
        void Undo();
    }
}