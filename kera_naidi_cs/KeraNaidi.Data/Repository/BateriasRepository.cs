using KeraNaidi.Data;
using KeraNaidi.Data.IRepository;
using KeraNaidi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KeraNaidi.Data.Repository;

public class BateriasRepository<TId, TEntity> : IBateriasRepository<TId, TEntity>
where TId : struct
where TEntity : BaseEntity<TId>
{
    internal KeraNaidiContext _context;
    internal DbSet<TEntity> _dbSet;
    
    public BateriasRepository(KeraNaidiContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
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