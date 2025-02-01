using KeraNaidi.Data;
using KeraNaidi.Data.IRepository;
using KeraNaidi.Data.Models;
using Microsoft.EntityFrameworkCore;

public class ProductRepository<TId, TEntity> : IProductRepository<TId, TEntity>
where TId : struct
where TEntity : BaseEntity<TId>
{
    internal KeraNaidiContext _context;
    internal DbSet<TEntity> _dbSet;
    
    public ProductRepository(KeraNaidiContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    
    public async Task AddAsync(TEntity product)
    {
        await _dbSet.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity> FindAsync(TId id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
}