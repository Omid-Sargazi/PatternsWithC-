namespace DesignPattern.BridgePattern
{

    public interface IDrawApi
    {
        void DrawCircle();
        void DrawSquare();
    }

    public class OpenGLDrawer : IDrawApi
    {
        public void DrawCircle()
        {
            Console.WriteLine("Circle with OpenGL");
        }

        public void DrawSquare()
        {
            Console.WriteLine("Square with OpenGL");
        }
    }

    public class DirectXDrawer : IDrawApi
    {
        public void DrawCircle()
        {
            Console.WriteLine("Circle with DirectX");
        }

        public void DrawSquare()
        {
            Console.WriteLine("Square with DirectX");
        }
    }

    public abstract class Shape
    {
        protected IDrawApi _drawer;
        public Shape(IDrawApi drawer)
        {
            _drawer = drawer;
        }

        public abstract void Draw();
    }

    public class Circle : Shape
    {
        public Circle(IDrawApi drawer) : base(drawer)
        {
        }

        public override void Draw()
        {
            _drawer.DrawCircle();
        }
    }

    public class Square : Shape
    {
        public Square(IDrawApi drawer) : base(drawer)
        {
        }

        public override void Draw()
        {
            _drawer.DrawSquare();
        }
    }

    public class CircleOpenGL
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Circle using OpenGL");
        }
    }


    public class SquareOpenGL
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Square using OpenGL");
        }
    }

    public class CircleDirectX
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Circle using DirectX");
        }
    }

    public class SquareDirectX
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Square using DirectX");
        }
    }


}