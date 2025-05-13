namespace BehavioralPattern02.PrototypePattern
{
    public class Circle
    {
        public double Radius {get; set;}
        public string Color {get; set;}
        public Circle(double redius, string color)
        {
            Radius = redius;
            Color = color;
        }
        public Circle Copy()
        {
            return new Circle(Radius, Color);
        }
        public void Describe()
        {
            Console.WriteLine($"Circle: Radius={Radius}, Color={Color}");
        }
    }

    public class Rectangle
    {
        public double Width {get; set;}
        public double Height {get; set;}
        public string Color {get; set;}

        public Rectangle(double width, double height, string color)
        {
            Width = width;
            Height = height;
            Color = color;
        }

        public Rectangle Copy()
        {
            return new Rectangle(Width, Height, Color);
        }

        public void Describe()
        {
            Console.WriteLine($"Rectangle: Width={Width}, Height={Height}, Color={Color}");
        }
    }

    public class Triangle
    {
        public double Side1 {get; set;}
        public double Side2 {get; set;}
        public double Side3 {get; set;}
        public string Color {get; set;}

        public Triangle(double side1, double side2, double side3, string color)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
            Color = color;
        }

        public Triangle Copy()
        {
            return new Triangle(Side1,Side2, Side3, Color);
        }

        public void Describe()
        {
            Console.WriteLine($"Triangle: Sides={Side1},{Side2},{Side3}, Color={Color}");
        }
    }
}