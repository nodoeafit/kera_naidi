using KeraNaidi.Data.Entities;
using KeraNaidi.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KeraNaidi.Data;

public class KeraNaidiContext : IdentityDbContext<ApplicationUser>
{
    public KeraNaidiContext(DbContextOptions<KeraNaidiContext> options) : base(options){
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior",true);
    }

    public DbSet<HealthCheck> HealthCheck {get;set;}
    public DbSet<Product> Products{get;set;}
    public DbSet<Ubicacion> Ubicacion {get;set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if(modelBuilder == null)
        {
            return;
        }
        modelBuilder.Entity<HealthCheck>().ToTable("HealthCheck").HasKey(x => x.Id);
        modelBuilder.Entity<Product>().ToTable("Product").HasKey(x => x.Id);
        modelBuilder.Entity<Ubicacion>().ToTable("Ubicacion").HasKey(x => x.Id);
        base.OnModelCreating(modelBuilder);
    }
}
