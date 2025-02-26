using KeraNaidi.Data.Models;

namespace KeraNaidi.Interfaces;

public interface IHealthService
{
    public Task<string> HealthCheck();
    public Task<List<HealthCheck>> DbCheck();
    public Task<List<HealthCheck>> AddHealthCheck(HealthCheck healthCheck);
}