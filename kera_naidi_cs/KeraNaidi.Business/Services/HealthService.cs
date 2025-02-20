namespace KeraNaidi.Services;

using System.Collections.Generic;
using System.Security;
using KeraNaidi.Data;
using KeraNaidi.Data.IRepository;
using KeraNaidi.Data.Models;
using KeraNaidi.Interfaces;

public class HealthService : IHealthService
{
    
    //private IHealthRepository<int, HealthCheck> _healthRepository;
    private readonly IUnitOfWork _unitOfWork;
    //private readonly KeraNaidiContext _context;

    public HealthService(IUnitOfWork unitOfWork)
    {
        // _context = context;
        // _healthRepository = new HealthRepository<int, HealthCheck>(_context);
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<HealthCheck>> AddHealthCheck(HealthCheck healthCheck)
    {
        //await _healthRepository.AddAsync(healthCheck);
        //return new List<HealthCheck>{ healthCheck};
        //var check = await _unitOfWork.HealthRepository.FindAsync(1);
        return new List<HealthCheck>();
    }

    public async Task<List<HealthCheck>> DbCheck()
    {
        // var check = await _healthRepository.FindAsync(1);
        // return new List<HealthCheck>{check};
        var check = await _unitOfWork.HealthRepository.FindAsync(1);
        var productos = await _unitOfWork.ProductRepository.GetAllAsync(x => x.Code.Contains("DDR556"));
        var ubicacion = new Ubicacion(){
            Nombre = "El Stand de Los Pibes Chorros",
            FechaRegistro = DateTime.Now,
            HorarioApertura = DateTime.Now.AddDays(2),
            HorarioCierre = DateTime.Now.AddDays(3),
            Latitud = 6.25184,
            Longitud = -75.56359
        };
        
        await _unitOfWork.UbicacionRepository.AddAsync(ubicacion);
        await _unitOfWork.SaveAsync();
        
        return new List<HealthCheck>(){check};

    }

    public async Task<string> HealthCheck()
    {
        return "Check made at: " + DateTime.Now.ToString("yyyy-mm-dd");
    }
}