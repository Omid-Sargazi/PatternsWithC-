namespace PatternsInCSharp.BidgePattern.ShapeRandering
{
    public abstract class Shape
    {
        public abstract void Draw();
    }

    public class CircleVector : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Circle using Vector rendering");
        }
    }

    public class CirclePixel : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Circle using Pixel rendering");
        }
    }

    public class SquareVector : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Square using Vector rendering");
        }
    }

    public class SquarePixel : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Square using Pixel rendering");
        }
    }
}