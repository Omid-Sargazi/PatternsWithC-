namespace CompositePattern.CommandPattern
{
    public class TV
    {
        public bool IsOn {get; private set;}
        public int Volume {get; private set;}

    
        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine("TV is ON");
        }

    public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine("TV is OFF");
        }

    public void VolumeUp()
        {
            Volume += 10;
            Console.WriteLine($"Volume: {Volume}");
        }

    public void VolumeDown()
        {
            Volume -= 10;
            Console.WriteLine($"Volume: {Volume}");
        }
    }
}