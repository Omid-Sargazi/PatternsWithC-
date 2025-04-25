namespace PatternsInCSharp.AbstractFactory.PC
{
    using PatternsInCSharp.AbstractFactory;

    /// <summary>
    /// The 'AbstractProduct' interface.
    /// </summary>
    public interface IProcessor
    {
        string GetProcessor();
    }

    public interface IGraphicsCard 
    {
        string GetGraphicsCard();
    }

    public interface IRAM
    {
        string GetRAM();
    }
}