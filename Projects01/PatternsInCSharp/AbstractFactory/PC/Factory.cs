namespace PatternsInCSharp.AbstractFactory.PC
{
    using PatternsInCSharp.AbstractFactory;

    /// <summary>
    /// The 'ConcreteFactory' class.
    /// </summary>
    public class Factory : IFactory
    {
        public IGamingPC CreateGamingPC()
        {
            throw new NotImplementedException();
        }

        // public IGamingPC CreateGamingPC()
        // {
        //     return new GamingPC();
        // }

        public IGraphicsCard CreateGraphicsCard()
        {
            throw new NotImplementedException();
        }

        public IOfficePC CreateOfficePC()
        {
            return new OfficePC();
        }

        public IProcessor CreateProcessor()
        {
            throw new NotImplementedException();
        }

        public IRAM CreateRAM()
        {
            throw new NotImplementedException();
        }
    }
}