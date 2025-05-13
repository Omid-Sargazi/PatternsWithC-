namespace BehavioralPattern02.PrototypePattern
{

    public abstract class Shape
    {
        public string Color {get; set;}
        public Shape(string color)
        {
            Color = color;
        }
        // public abstract Shape Copy();
        public abstract void Describe();

        public Shape ShallowCopy()
        {
            return (Shape)MemberwiseClone();
        }
    }
    public class Circle : Shape
    {
        public double Radius {get; set;}
        public Circle(double radius ,string color) : base(color)
        {
            Radius = radius;
        }

        // public override Shape Copy()
        // {
        //     return new Circle(Radius, Color);
        // }

        public override void Describe()
        {
            Console.WriteLine($"Circle: Radius={Radius}, Color={Color}");
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle(double width, double height,string color) : base(color)
        {
            Width = width;
            Height = height;
        }

        public double Width {get; set;}
        public double Height {get; set;}

        // public override Shape Copy()
        // {
        //     return new Rectangle(Width, Height, Color);
        // }

        public override void Describe()
        {
            Console.WriteLine($"Rectangle: Width={Width}, Height={Height}, Color={Color}");
        }
    }

    public class Triangle : Shape
    {
        public Triangle(double side1, double side2 , double side3, string color) : base(color)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        public double Side1 {get; set;}
        public double Side2 {get; set;}
        public double Side3 {get; set;}

        // public override Shape Copy()
        // {
        //     return new Triangle(Side1, Side2, Side3, Color);
        // }

        public override void Describe()
        {
            Console.WriteLine($"Triangle: Sides={Side1},{Side2},{Side3}, Color={Color}");
        }
    }
}