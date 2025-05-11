using System.Runtime.CompilerServices;

namespace BehavioralPattern02.VisitorPattern
{
    public abstract class Shape
    {
        
    }

    public class Circle : Shape
    {
        public double Radius {get; set;}
        public Circle(double radius)
        {
            Radius = radius;
        }
       
    }

    public class Rectangle : Shape
    {
        public double Width {get; set;}
        public double Height {get; set;}
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
       
    }

    public class ShapeOperations
    {
        public double CalculateArea(Shape shape)
        {
            if(shape is Circle circle)
            {
                return Math.PI * circle.Radius * circle.Radius;
            }
            else if(shape is Rectangle rectangle)
            {
                return rectangle.Width * rectangle.Height;
            }
            throw new NotSupportedException("Shape not supported");
        }

        public double CalculatePerimeter(Shape shape)
        {
            if(shape is Circle circle)
            {
                return Math.PI * 2 * circle.Radius;
            }
            else if(shape is Rectangle rectangle)
            {
                return 2*(rectangle.Width + rectangle.Height);
            }
            throw new NotSupportedException("Shape not supported");
        }

        public void Draw(Shape shape)
        {
            if(shape is Circle circle)
            {
                Console.WriteLine($"Drawing Circle with radius: {circle.Radius}");
            }

            else if(shape is Rectangle rectangle)
            {
                Console.WriteLine($"Drawing Rectangle with width: {rectangle.Width}, height: {rectangle.Height}");
            }
            else
                throw new NotSupportedException("Shape not supported");
        }
    }
}