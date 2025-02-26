using KeraNaidi.Data.Models;

namespace KeraNaidi.Data.IRepository;

public interface IBateriasRepository<TId, TEntity>
where TId: struct
where TEntity : BaseEntity<TId>
{
    Task<TEntity> FindAsync(TId id);
    Task<IEnumerable<TEntity>> GetAllAsync();
}