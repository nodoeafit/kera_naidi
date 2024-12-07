using KeraNaidi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KeraNaidi.Data;

public class KeraNaidiContext : DbContext
{
    public KeraNaidiContext(DbContextOptions options) : base(options){}

    public DbSet<HealthCheck> HealthCheck {get;set;} = null;
}
