namespace Patterns.CommandPattern.WithoutPattern
{
    public class Television
    {
        public void TurnOn()
        {
            Console.WriteLine("Television is turned on.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Television is turned off.");
        }
        public void ChangeChannel(int channel)
        {
            Console.WriteLine($"کانال به شماره {channel} تغییر کرد");
        }

        public void VolumeUp()
        {
            Console.WriteLine("صدا افزایش یافت");
        }

        public void VolumeDown()
        {
            Console.WriteLine("صدا کاهش یافت");
        }
    }
}