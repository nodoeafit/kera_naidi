using KeraNaidi.Data.Models;

public interface IProductService
{
    Task<Product> AddProduct(Product product);
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product> GetProductById(int id);
}
