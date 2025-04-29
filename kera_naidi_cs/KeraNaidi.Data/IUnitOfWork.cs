using KeraNaidi.Data.Entities;
using KeraNaidi.Data.Models;

namespace KeraNaidi.Data;

public interface IUnitOfWork
{
    IRepository<int, HealthCheck> HealthRepository{get;}
    IRepository<int, Product> ProductRepository{get;}
    IRepository<int, Ubicacion> UbicacionRepository{get;}
    IRepository<int, Reto> RetoRepository{get;}
    Task SaveAsync();
}