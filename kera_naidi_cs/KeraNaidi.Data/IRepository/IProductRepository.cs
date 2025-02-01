using KeraNaidi.Data.Models;

namespace KeraNaidi.Data.IRepository;

public interface IProductRepository<TId, TEntity>
where TId: struct
where TEntity : BaseEntity<TId>
{
    Task AddAsync(TEntity product);
    Task<TEntity> FindAsync(TId id);
    Task<IEnumerable<TEntity>> GetAllAsync();
}