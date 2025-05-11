namespace BehavioralPattern02.VisitorPattern
{
    public abstract class Shape
    {
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }

    public class Circle : Shape
    {
        public double Radius {get; set;}
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double CalculatePerimeter()
        {
            return Math.PI * Radius * 2;
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
        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override double CalculatePerimeter()
        {
            return 2*(Width + Height);
        }
    }
}