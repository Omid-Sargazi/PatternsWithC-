namespace CompositePattern.Database
{
    public interface IProductRepository
    {
       Product GetProductById(int id);
       List<Product> GetAllProducts();
    }
}