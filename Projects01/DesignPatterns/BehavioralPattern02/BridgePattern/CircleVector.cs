namespace BehavioralPattern02.BridgePattern
{
    public interface IRenderer
    {
        void RenderShape(string shapeType);
    }

    public class VectorRender : IRenderer
    {
        public void RenderShape(string shapeType)
        {
            Console.WriteLine($"Drawing {shapeType} with Vector rendering");
        }
    }

    public class PixelRenderer : IRenderer
    {
        public void RenderShape(string shapeType)
        {
            Console.WriteLine($"Drawing {shapeType} with Pixel rendering");
        }
    }

    public class Renderer
    {
        public void RenderShape(string shapeType)
        {
            Console.WriteLine($"Rendering {shapeType} with some rendering method");
        }
    }
    public abstract class Shape
    {
        protected IRenderer _renderer;
        public Shape(IRenderer renderer)
        {
            _renderer = renderer;
        }
        public abstract void Draw();
    }
    public class Circle:Shape
    {
       private string _renderType;

        public Circle(IRenderer renderer) : base(renderer)
        {
        }

        public override void Draw()
        {
           _renderer.RenderShape("Circle");
        }
    }



    // public class CirclePixel
    // {
    //     public void Draw()
    //     {
    //         Console.WriteLine("Drawing Circle with Pixel rendering");
    //     }
    // }
    public class Square : Shape
    {
       private string _renderType;

        public Square(IRenderer renderer) : base(renderer)
        {
        }

        public override void Draw()
        {
          _renderer.RenderShape("Square");
        }
    }

   
}