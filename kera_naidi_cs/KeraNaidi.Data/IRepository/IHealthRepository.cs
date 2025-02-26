using System.Runtime.InteropServices;
using KeraNaidi.Data.Models;

namespace KeraNaidi.Data.IRepository;

public interface IHealthRepository<TId, TEntity>
where TId: struct
where TEntity : BaseEntity<TId>
{
    Task AddAsync(TEntity healthCheck);
    Task<TEntity> FindAsync(TId id);
}