namespace CompositePattern.FacadePattern
{
    public class TV
    {
        public void TurnOn() => Console.WriteLine("TV is on");
        public void SetInput(string input) => Console.WriteLine($"TV input set to {input}");
    }
}