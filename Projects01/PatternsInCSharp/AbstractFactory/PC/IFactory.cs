namespace PatternsInCSharp.AbstractFactory.PC
{
    public interface IFactory
    {
        IOfficePC CreateOfficePC();
        IGamingPC CreateGamingPC();
        IRAM CreateRAM();
        IGraphicsCard CreateGraphicsCard();
        IProcessor CreateProcessor();
    }
}