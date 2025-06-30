namespace DesignPattern.BridgePattern
{
    public interface IDrawShapes
    {
        void DrawCircle();
        void DrawSquare();
        void DrawRectangle();
    }

    public class SVGMethod : IDrawShapes
    {
        public void DrawCircle()
        {
            Console.WriteLine("Draw Circle by SVG method");
        }

        public void DrawRectangle()
        {
            Console.WriteLine("Draw Rectangle by SVG method");

        }

        public void DrawSquare()
        {
            Console.WriteLine("Draw Square by SVG method");

        }
    }

    public class AsCIIMethod : IDrawShapes
    {
        public void DrawCircle()
        {
            Console.WriteLine("Draw Circle by ASCII method");

        }

        public void DrawRectangle()
        {
            Console.WriteLine("Draw Rectangle by ASCII method");

        }

        public void DrawSquare()
        {
            Console.WriteLine("Draw Square by ASCII method");

        }
    }

    public abstract class ShapeMethod
    {
        protected IDrawShapes _drawShapes;
        public ShapeMethod(IDrawShapes drawShapes)
        {
            _drawShapes = drawShapes;
        }

        public abstract void Draw();
    }

    public class Circlee : ShapeMethod
    {
        public Circlee(IDrawShapes drawShapes) : base(drawShapes)
        {
        }

        public override void Draw()
        {
            _drawShapes.DrawCircle();
        }
    }
}