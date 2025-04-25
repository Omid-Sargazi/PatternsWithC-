namespace PatternsInCSharp.AbstractFactory.PC
{
    public interface IFactory
    {
        IOfficePC CreateOfficePC();
        IGamingPC CreateGamingPC();
    }
}