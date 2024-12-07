using KeraNaidi.Data;
using KeraNaidi.Data.IRepository;
using KeraNaidi.Data.Models;
using Microsoft.EntityFrameworkCore;

public class HealthRepository<TId, TEntity> : IHealthRepository<TId, TEntity>
where TId : struct
where TEntity : BaseEntity<TId>
{
    internal KeraNaidiContext _context;
    internal DbSet<TEntity> _dbSet;
    
    public HealthRepository(KeraNaidiContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    
    public async Task AddAsync(TEntity healthCheck)
    {
        await _dbSet.AddAsync(healthCheck);
        await _context.SaveChangesAsync();
    }


    public async Task<TEntity> FindAsync(TId id)
    {
        return await _dbSet.FindAsync(id);
    }
}