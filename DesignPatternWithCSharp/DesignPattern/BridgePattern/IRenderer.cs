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

    public class CircleBridgee : ShapeBridgee
    {
        private readonly double _radius;
        private readonly double _centerX;
        private readonly double _centerY;
        public CircleBridgee(double radius, double centerX, double centerY, IRenderer renderer) : base(renderer)
        {
            _radius = radius;
            _centerX = centerX;
            _centerY = centerY;
        }

        public override string Draw()
        {
            string shapeData = $"Circle with radius {_radius} at center ({_centerX}, {_centerY})";
            return _renderer.RenderShape(shapeData);
        }
    }
}