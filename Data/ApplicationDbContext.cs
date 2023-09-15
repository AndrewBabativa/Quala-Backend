using Microsoft.EntityFrameworkCore;
using Quala.Models;

namespace Quala.Data
{ 
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SucursalDTO> Sucursales { get; set; }
        public DbSet<MonedaDTO> Monedas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SucursalDTO>()
               .ToTable("SucursalDTO");

            modelBuilder.Entity<MonedaDTO>()
               .ToTable("MonedaDTO");
        }
    }
}
