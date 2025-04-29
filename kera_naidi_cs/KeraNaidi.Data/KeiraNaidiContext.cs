using KeraNaidi.Data.Entities;
using KeraNaidi.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KeraNaidi.Data
{
    public class KeraNaidiContext : IdentityDbContext<ApplicationUser>
    {
        public KeraNaidiContext(DbContextOptions<KeraNaidiContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<HealthCheck> HealthCheck { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Ubicacion> Ubicacion { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Reto> Retos { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HealthCheck>().ToTable("HealthCheck").HasKey(x => x.Id);
            modelBuilder.Entity<Product>().ToTable("Product").HasKey(x => x.Id);
            modelBuilder.Entity<Ubicacion>().ToTable("Ubicacion").HasKey(x => x.Id);
            modelBuilder.Entity<Evento>().ToTable("Evento").HasKey(x => x.Id);
            modelBuilder.Entity<Reto>().ToTable("Reto").HasKey(x => x.Id);
            modelBuilder.Entity<Pregunta>().ToTable("Pregunta").HasKey(x => x.Id);

            modelBuilder.Entity<Pregunta>()
                .Property(p => p.RespuestasIncorrectas)
                .HasConversion(
                    v => string.Join(";", v ?? new List<string>()),
                    v => string.IsNullOrEmpty(v) ? new List<string>() : v.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList()
                );
        }
    }
}
