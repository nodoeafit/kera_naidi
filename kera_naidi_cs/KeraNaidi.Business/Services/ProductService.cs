using KeraNaidi.Data;
using KeraNaidi.Data.Models;

public class ProductService : IProductService
{
    private readonly KeraNaidiContext _context;


    public ProductService(KeraNaidiContext context)
    {
        _context = context;
        
    }
    
    public async Task<Product> AddProduct(Product product)
    {
        //await _productRepository.AddAsync(product);
        return product;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return null; //await _productRepository.GetAllAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
        throw new NotImplementedException();
    }
}