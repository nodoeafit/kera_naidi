using KeraNaidi.Data.Models;
using KeraNaidi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeraNaidi.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly KeraNaidiContext _context;
    private IRepository<int, HealthCheck> _healthRepository;
    private IRepository<int, Product> _productRepository;
    private IRepository<int, Ubicacion> _ubicacionRepository;
    private IRepository<int, Reto> _retoRepository; // 👉 agregado aquí
    private bool _disposed = false;

    public UnitOfWork(KeraNaidiContext context)
    {
        _context = context;
    }

    public IRepository<int, HealthCheck> HealthRepository
    {
        get
        {
            _healthRepository ??= new Repository<int, HealthCheck>(_context);
            return _healthRepository;
        }
    }

    public IRepository<int, Product> ProductRepository
    {
        get
        {
            _productRepository ??= new Repository<int, Product>(_context);
            return _productRepository;
        }
    }

    public IRepository<int, Ubicacion> UbicacionRepository
    {
        get
        {
            _ubicacionRepository ??= new Repository<int, Ubicacion>(_context);
            return _ubicacionRepository;
        }
    }

    public IRepository<int, Reto> RetoRepository // 👉 propiedad para Reto
    {
        get
        {
            _retoRepository ??= new Repository<int, Reto>(_context);
            return _retoRepository;
        }
    }

    public async Task SaveAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();
        }
    }

    #region IDisposable
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.DisposeAsync();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
    }
    #endregion
}
