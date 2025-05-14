namespace BehavioralPattern02.BridgePattern
{
    public abstract class Shape
    {
        public abstract void Draw();
    }
    public class Circle:Shape
    {
       private string _renderType;
       public Circle(string renderType)
       {
            _renderType = renderType;
       }

        public override void Draw()
        {
            if(_renderType=="Vector")
                Console.WriteLine("Drawing Circle with Vector rendering");
            else if(_renderType == "Pixel")
                Console.WriteLine("Drawing Circle with Pixel rendering");
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

        public Square(string renderType)
        {
            _renderType = renderType;
        }
        public override void Draw()
        {
           if (_renderType == "Vector")
            Console.WriteLine("Drawing Square with Vector rendering");
        else if (_renderType == "Pixel")
            Console.WriteLine("Drawing Square with Pixel rendering");
        }
    }

   
}