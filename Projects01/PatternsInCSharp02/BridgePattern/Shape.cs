namespace PatternsInCSharp02.BridgePattern
{
    public abstract class Shape
    {
        protected Irendering _irendering;
        public Shape(Irendering irendering)
        {
            _irendering = irendering;
        }
        public abstract void Draw();
    }

    public class Circle : Shape
    {
        public Circle(Irendering irendering) : base(irendering)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a circle");
            _irendering.Render();
        }
    }

    public class Square : Shape
    {
        public Square(Irendering irendering) : base(irendering)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a square");
            _irendering.Render();
        }
    }

    public interface Irendering
    {
        void Render();
    }

    public class VectorRendering : Irendering
    {
        public void Render()
        {
            Console.WriteLine("Rendering using vector graphics");
        }
    }

    public class PixelRendering : Irendering
    {
        public void Render()
        {
            Console.WriteLine("Rendering using pixel graphics");
        }
    }
}