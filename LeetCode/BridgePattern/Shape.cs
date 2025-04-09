namespace LeetCode.BridgePattern
{
    public class Shape
    {
        private IDrawingTool _drawingTool;
        public Shape(IDrawingTool drawingTool)
        {
            _drawingTool = drawingTool;
        }
        public string Name {get; set;}
        public string Draw()
        {
            return $"{Name} is drawn with {_drawingTool.DrawStyle()}";
        }
    }
}