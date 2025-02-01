using KeraNaidi.Data;
using KeraNaidi.Data.IRepository;
using KeraNaidi.Data.Models;

public class ProductService : IProductService
{
    private readonly KeraNaidiContext _context;
    private IProductRepository<int, Product> _productRepository;

    public ProductService(KeraNaidiContext context)
    {
        _context = context;
        _productRepository = new ProductRepository<int, Product>(_context);
    }
    
    public async Task<Product> AddProduct(Product product)
    {
        await _productRepository.AddAsync(product);
        return product;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
        throw new NotImplementedException();
    }
}