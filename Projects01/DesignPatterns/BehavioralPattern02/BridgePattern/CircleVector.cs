namespace BehavioralPattern02.BridgePattern
{
    public class Renderer
    {
        public void RenderShape(string shapeType)
        {
            Console.WriteLine($"Rendering {shapeType} with some rendering method");
        }
    }
    public abstract class Shape
    {
        protected Renderer _renderer;
        public Shape(Renderer renderer)
        {
            _renderer = renderer;
        }
        public abstract void Draw();
    }
    public class Circle:Shape
    {
       private string _renderType;

        public Circle(Renderer renderer) : base(renderer)
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

        public Square(Renderer renderer) : base(renderer)
        {
        }

        public override void Draw()
        {
          _renderer.RenderShape("Square");
        }
    }

   
}