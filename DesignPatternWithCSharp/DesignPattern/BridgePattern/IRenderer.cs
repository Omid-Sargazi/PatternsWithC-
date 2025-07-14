namespace DesignPattern.BridgePattern
{
    public interface IRenderer
    {
        string RenderShape(string shapeData);
    }

    public class WebRendere : IRenderer
    {
        public string RenderShape(string shapeData)
        {
            return $"Rendering shape as JSON for Web: {{ shape: \"{shapeData}\" }}";
        }
    }

    public class WindowsRenderer : IRenderer
    {
        public string RenderShape(string shapeData)
        {
            return $"Rendering shape as text for Windows: {shapeData}";
        }
    }

    public abstract class ShapeBridgee
    {
        protected IRenderer _renderer;
        protected ShapeBridgee(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public abstract string Draw();
    }
}