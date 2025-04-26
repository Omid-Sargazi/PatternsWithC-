namespace PatternsInCSharp.BidgePattern.ShapeRandering
{
    public interface IRenderer
    {
        void RenderShape(string shapeName);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderShape(string shapeName)
        {
            Console.WriteLine($"Drawing {shapeName} using Vector rendering");
        }
    }

    public class PixelRenderer : IRenderer
    {
        public void RenderShape(string shapeName)
        {
            Console.WriteLine($"Drawing {shapeName} using Pixel rendering");
        }
    }

    public abstract class Shapee
    {
        protected IRenderer _renderer;
        public Shapee(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public abstract void Draw();
    }

    public class Circlee : Shapee
    {
        public Circlee(IRenderer renderer) : base(renderer)
        {
        }

        public override void Draw()
        {
            _renderer.RenderShape("circle");
        }
    }

    public class Squaree : Shapee
    {
        public Squaree(IRenderer renderer) : base(renderer)
        {
        }

        public override void Draw()
        {
            _renderer.RenderShape("square");
        }
    }

    public class Client
    {
        public void render()
        {
            IRenderer vectorRender = new VectorRenderer();
            IRenderer pixelRenderer = new PixelRenderer();

            Shapee circleVector = new Circlee(vectorRender);
            Shapee circlePixel = new Circlee(pixelRenderer);

            Shapee squareVector = new Squaree(vectorRender);
            Shapee squarePixel = new Squaree(pixelRenderer);
        }
    }
}