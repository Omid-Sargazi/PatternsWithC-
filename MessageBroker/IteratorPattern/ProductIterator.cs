namespace MessageBroker.IteratorPattern
{
    public class ProductIterator : IIterator<string>
    {
        private readonly List<string> _products;
        private int _index = 0;
        public ProductIterator(List<string> products)
        {
            _products = products;
        }
        
        public string Current()
        {
            return _products[_index];
        }

        public bool MoveNext()
        {
            _index++;
            return _index < _products.Count();
        }

        public void Reset()
        {
            _index = 0;
        }
    }
}