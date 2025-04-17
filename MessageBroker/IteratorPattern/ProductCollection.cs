namespace MessageBroker.IteratorPattern
{
    public class ProductCollection : IAggregate<string>
    {
        private List<string> _products = new List<string>();
        public void Add(string product)
        {
            _products.Add(product);
        }

        public IIterator<string> CreateIterator()
        {
            return new ProductIterator(_products);
        }
    }
}