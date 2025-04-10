
namespace CompositePattern.Database
{
    public class DatabaseProductRepository : IProductRepository
    {
        public List<Product> GetAllProducts()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Fetched all products from database");
            return new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.0 },
                new Product { Id = 2, Name = "Product 2", Price = 20.0 },
            };
        }

        public Product GetProductById(int id)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Fetched product {id} from database");
            return new Product {Id = id, Name = $"Product{id}", Price = id*10};
        }
    }
}