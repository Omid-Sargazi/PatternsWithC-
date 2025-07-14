using System.Reflection.Metadata;

namespace DesignPattern.BridgePattern
{
    public interface IShapeDraw
    {
        string RenderShape(string shapeDate);
    }

    public class WinWayDarw : IShapeDraw
    {
        public string RenderShape(string shapeData)
        {
            return $"Rendering shape as text for Windows: {shapeData}";
        }
    }

    public class MacWayDraw : IShapeDraw
    {
        public string RenderShape(string shapeData)
        {
            return $"Rendering shape as JSON for Mac: {{ shape: \"{shapeData}\" }}";
        }
    }

    public abstract class ShapeBridge
    {
        protected IShapeDraw _shapeDraw;
        protected ShapeBridge(IShapeDraw shapeDraw)
        {
            _shapeDraw = shapeDraw;
        }
        public abstract string Draw();
    }

    public class CircleBridge : ShapeBridge
    {
        private readonly double _radius;
        private readonly double _centerX;
        private readonly double _centerY;

        public CircleBridge(IShapeDraw shapeDraw, double radius, double centerX, double centerY) : base(shapeDraw)
        {
            _centerX = centerX;
            _centerY = centerY;
            _radius = radius;
        }

        public override string Draw()
        {
            string shapeData = $"Circle with radius {_radius} at center ({_centerX}, {_centerY})";
            return _shapeDraw.RenderShape(shapeData);
        }
    }

    public class TriangleBridge : ShapeBridge
    {
         private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;

        public TriangleBridge(IShapeDraw shapeDraw, double sideA, double sideB, double sideC) : base(shapeDraw)
        {
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
        }

        public override string Draw()
        {
            string shapeData = $"Triangle with sides {_sideA}, {_sideB}, {_sideC}";
            return _shapeDraw.RenderShape(shapeData);
        }
    }
}