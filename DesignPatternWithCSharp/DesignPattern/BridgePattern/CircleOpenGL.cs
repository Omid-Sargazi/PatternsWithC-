namespace DesignPattern.BridgePattern
{
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