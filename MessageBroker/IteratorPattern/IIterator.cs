namespace MessageBroker.IteratorPattern
{
    public interface IIterator<T>
    {
       T Current();
       bool MoveNext();
       void Reset();
    }
}