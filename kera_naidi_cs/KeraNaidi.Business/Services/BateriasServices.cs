using KeraNaidi.Data;
using KeraNaidi.Data.IRepository;
using KeraNaidi.Data.Repository;

using KeraNaidi.Data.Models;
using KeraNaidi.Interfaces;

namespace KeraNaidi.Services;

public class BateriasService : IBateriasService
{
    private readonly KeraNaidiContext _context;
    private IBateriasRepository<int, Baterias> _BateriasRepository;

    public BateriasService(KeraNaidiContext context)
    {
        _context = context;
        _BateriasRepository = new BateriasRepository<int, Baterias>(_context);
    }

    //public Task<Baterias> AddBaterias(Baterias baterias)
    //{
    //    throw new NotImplementedException();
    //}


    public Task<Baterias> GetBateriasById(int id)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<Baterias>> IBateriasService.GetAllBaterias()
    {
        return _BateriasRepository.GetAllAsync();
    }


}