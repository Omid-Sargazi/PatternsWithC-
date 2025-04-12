namespace CompositePattern.CommandPattern
{
    public class DrawingMediator : IDrawingMediator
    {
        private Canvas _canvas;
        public DrawingMediator(Canvas canvas)
        {
            _canvas = canvas;
        }
        public void DrawShape(string shapeType, params int[] parameters)
        {
            _canvas.Draw(shapeType, parameters);
        }

        public void EraseShape(string shapeType, params int[] parameters)
        {
            _canvas.Erase(shapeType, parameters);
        }
    }
}