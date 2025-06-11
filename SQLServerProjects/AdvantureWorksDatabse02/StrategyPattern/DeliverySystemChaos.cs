namespace AdvantureWorksDatabse02.StrategyPattern
{
    public class DataProcessor
    {
        protected delegate IEnumerable<T> DataPocessorr<T>(IEnumerable<T> data);

        public void Process()
        {
            var numbers = new List<int> { 1, 2, 2, 3, 4, 5, 6, 7, 8, 9 };
            DataPocessorr<int> doubleNumbers = data => data.Select(x => x * 2);
            DataPocessorr<int> filterEvent = data => data.Where(x => x % 2 == 0);
            DataPocessorr<int> filterBig = data => data.Where(x => x > 5);
        }


        private static IEnumerable<T> ApplyProcessor<T>(IEnumerable<T> data, DataPocessorr<T> processor)
        {
            return processor(data);
        }

        private static IEnumerable<T> ApplyProcessors<T>(IEnumerable<T> data, params DataPocessorr<T>[] processors)
        {
            IEnumerable<T> result = data;
            foreach (var processor in processors)
            {
                result = processor(data);
            }
            return result;
        }
    }
}