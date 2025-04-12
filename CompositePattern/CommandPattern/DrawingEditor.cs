namespace CompositePattern.CommandPattern
{
    public class DrawingEditor
    {
        private Stack<IDrawCommand> _undoStack = new Stack<IDrawCommand>();
    private Stack<IDrawCommand> _redoStack = new Stack<IDrawCommand>();

    public void ExecuteCommand(IDrawCommand command)
    {
        command.Execute();
        _undoStack.Push(command);
        _redoStack.Clear();
        Console.WriteLine("Operation executed.");
    }

    public void Undo()
    {
        if (_undoStack.Count > 0)
        {
            var command = _undoStack.Pop();
            command.Undo();
            _redoStack.Push(command);
            Console.WriteLine("Undo performed.");
        }
        else
        {
            Console.WriteLine("Nothing to undo.");
        }
    }

    public void Redo()
    {
        if (_redoStack.Count > 0)
        {
            var command = _redoStack.Pop();
            command.Execute();
            _undoStack.Push(command);
            Console.WriteLine("Redo performed.");
        }
        else
        {
            Console.WriteLine("Nothing to redo.");
        }
    }
    }
}