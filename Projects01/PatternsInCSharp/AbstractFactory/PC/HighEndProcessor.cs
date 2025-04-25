namespace PatternsInCSharp.AbstractFactory.PC
{
    /// <summary>
    /// The 'ConcreteProduct' class.
    /// </summary>
    public class HighEndProcessor : IProcessor
    {
        public string GetProcessor()
        {
            return "Intel i9 13900K";
        }
    }

    public class HighEndGraphicsCard : IGraphicsCard
    {
        public string GetGraphicsCard()
        {
           return "NVIDIA RTX 4090";
        }
    }

    public class HighEndRAM : IRAM
    {
        public string GetRAM()
        {
            return "32GB DDR5";
        }
    }

    public class LowEndProcessor : IProcessor
    {
        public string GetProcessor()
        {
            return "Intel i3 12100";
        }
    }
    public class IntegratedGraphicsCard : IGraphicsCard
    {
        public string GetGraphicsCard()
        {
            return "Intel UHD Graphics";
        }
    }

    public class LowEndRAM : IRAM
    {
        public string GetRAM()
        {
            return "8GB DDR4";
        }
    }

}