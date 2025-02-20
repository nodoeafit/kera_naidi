using KeraNaidi.Data.Models;

namespace KeraNaidi.Data;

public interface IUnitOfWork
{
    IRepository<int, HealthCheck> HealthRepository{get;}
    IRepository<int, Product> ProductRepository{get;}
    IRepository<int, Ubicacion> UbicacionRepository{get;}
    Task SaveAsync();
}