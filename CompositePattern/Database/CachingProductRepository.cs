
namespace CompositePattern.Database
{
    public class CachingProductRepository : IProductRepository
    {
        private DatabaseProductRepository _realRepo;
        private Dictionary<int, Product> _cache = new Dictionary<int, Product>();
        private readonly object _lock = new object();
        public CachingProductRepository(DatabaseProductRepository repository)
        {
            _realRepo = repository;
        }
        public List<Product> GetAllProducts()
        {
            return _realRepo.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            lock(_lock)
            {
                if(_cache.ContainsKey(id))
                {
                    Console.WriteLine($"Retrieved product {id} from cache");
                    return _cache[id];
                }

            }
            var product = _realRepo.GetProductById(id);
            lock (_lock)
        {
            _cache[id] = product;
        }
            return product;
        }
        public void UpdateProduct(Product product)
        {
            Console.WriteLine($"Updated product {product.Id} in database");
            _cache.Remove(product.Id); // کش رو invalidate کن
        }
    }
}