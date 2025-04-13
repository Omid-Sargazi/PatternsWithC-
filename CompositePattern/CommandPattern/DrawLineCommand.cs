namespace CompositePattern.CommandPattern
{
    public class DrawLineCommand : IDrawCommand
    {
       private IDrawingMediator _mediator;
    private int _x1, _y1, _x2, _y2;

    public DrawLineCommand(IDrawingMediator mediator, int x1, int y1, int x2, int y2)
    {
        _mediator = mediator;
        _x1 = x1;
        _y1 = y1;
        _x2 = x2;
        _y2 = y2;
    }

    public void Execute()
    {
        _mediator.DrawShape("Line", _x1, _y1, _x2, _y2);
    }

    public void Undo()
    {
        _mediator.EraseShape("Line", _x1, _y1, _x2, _y2);
    }   
    }
}