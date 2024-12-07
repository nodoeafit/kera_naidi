namespace KeraNaidi.Services;

using System.Collections.Generic;
using KeraNaidi.Data;
using KeraNaidi.Data.IRepository;
using KeraNaidi.Data.Models;
using KeraNaidi.Interfaces;

public class HealthService : IHealthService
{
    
    private IHealthRepository<int, HealthCheck> _healthRepository;
    private readonly KeraNaidiContext _context;

    public HealthService(KeraNaidiContext context)
    {
        _context = context;
        _healthRepository = new HealthRepository<int, HealthCheck>(_context);
    }
    
    public async Task<List<HealthCheck>> AddHealthCheck(HealthCheck healthCheck)
    {
        await _healthRepository.AddAsync(healthCheck);
        return new List<HealthCheck>{ healthCheck};
    }

    public async Task<List<HealthCheck>> DbCheck()
    {
        var check = await _healthRepository.FindAsync(1);
        return new List<HealthCheck>{check};
    }

    public async Task<string> HealthCheck()
    {
        return "Check made at: " + DateTime.Now.ToString("yyyy-mm-dd");
    }
}