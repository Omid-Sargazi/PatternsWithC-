using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace BehavioralPattern02.VisitorPattern
{
    public abstract class Shape
    {
        
    }

    public class Circle : IShape
    {
        public double Radius {get; set;}
        public Circle(double radius)
        {
            Radius = radius;
        }

        public void Accept(IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Rectangle : IShape
    {
        public double Width {get; set;}
        public double Height {get; set;}
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public void Accept(IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ShapeOperations : IShapeVisitor
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

        public void Visit(Circle circle)
        {
            throw new NotImplementedException();
        }

        public void Visit(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }
    }

    public class CalculateArea : IShapeVisitor
    {
        public double Visit(Circle circle)
        {
            return Math.PI * circle.Radius * circle.Radius;
        }

        public double Visit(Rectangle rectangle)
        {
            return rectangle.Width * rectangle.Height;
        }
    }

    public class CalculatePerimeter : IShapeVisitor
    {
        public double Visit(Circle circle)
        {
            return 2*Math.PI*circle.Radius;
        }

        public double Visit(Rectangle rectangle)
        {
            return 2*(rectangle.Width + rectangle.Height);
        }
    }

    public class DrawVisitor : IShapeVisitor
    {
        public double Visit(Circle circle)
        {
            Console.WriteLine($"Drawing Circle with radius: {circle.Radius}");
            return circle.Radius;
        }

        public double Visit(Rectangle rectangle)
        {
             Console.WriteLine($"Drawing Rectangle with width: {rectangle.Width}, height: {rectangle.Height}");
             return rectangle.Width;
        }
    }

    public interface IShape
    {
        void Accept(IShapeVisitor visitor);
    }

    public interface IShapeVisitor
    {
        double Visit(Circle circle);
        double Visit(Rectangle rectangle);
    }


}