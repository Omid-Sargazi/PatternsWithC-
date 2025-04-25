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
            return new GamingPC();
        }

        public IOfficePC CreateOfficePC()
        {
            return new OfficePC();
        }
    }
}