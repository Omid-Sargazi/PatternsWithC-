namespace PatternsInCSharp.AbstractFactory.PC
{
    public class GamingPC : IGamingPC
    {
        private readonly IProcessor _processor;
        private readonly IGraphicsCard _graphicsCard;
        private readonly IRAM _ram;
        public GamingPC(IProcessor processor, IGraphicsCard graphicsCard, IRAM ram)
        {
            _processor = processor;
            _graphicsCard = graphicsCard;
            _ram = ram;
        }
        
        public void Assemble()
        {
            Console.WriteLine($"Assembling Gaming PC with: {_processor.GetProcessor()}, {_graphicsCard.GetGraphicsCard()}, {_ram.GetRAM()}");
        }

        public void Test()
        {
            Console.WriteLine("Testing Gaming PC: Running benchmarks...");
        }
    }
}