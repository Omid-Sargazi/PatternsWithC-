namespace AdvantureWorksDatabse02.StrategyPattern
{
    public class DataProcessorGood
    {
        public delegate IEnumerable<T> DataProcessor<T>(IEnumerable<T> data);
    }
}