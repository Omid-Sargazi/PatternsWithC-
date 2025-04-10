
namespace CompositePattern.Database
{
    public class CachingProductRepository : IProductRepository
    {
        private DatabaseProductRepository _realRepo = new DatabaseProductRepository();
        private Dictionary<int, Product> _cache = new Dictionary<int, Product>();
        public List<Product> GetAllProducts()
        {
            return _realRepo.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            if(_cache.ContainsKey(id))
            {
                Console.WriteLine($"Retrieved product {id} from cache");
                return _cache[id];
            }
            var product = _realRepo.GetProductById(id);
            return product;
        }
    }
}