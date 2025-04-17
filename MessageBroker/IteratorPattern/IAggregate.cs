namespace MessageBroker.IteratorPattern
{
    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
    }
}