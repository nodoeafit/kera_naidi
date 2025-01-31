using KeraNaidi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KeraNaidi.Data;

public class KeraNaidiContext : DbContext
{
    public KeraNaidiContext(DbContextOptions<KeraNaidiContext> options) : base(options){
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior",true);
    }

    public DbSet<HealthCheck> HealthCheck {get;set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if(modelBuilder == null)
        {
            return;
        }
        modelBuilder.Entity<HealthCheck>().ToTable("HealthCheck").HasKey(x => x.Id);
        modelBuilder.Entity<Product>().ToTable("Product").HasKey(x => x.Id);
        base.OnModelCreating(modelBuilder);
    }
}
