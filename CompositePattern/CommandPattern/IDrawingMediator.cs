namespace CompositePattern.CommandPattern
{
    public interface IDrawingMediator
    {
        void DrawShape(string shapeType, params int[] parameters);
         void EraseShape(string shapeType, params int[] parameters);
    }
}