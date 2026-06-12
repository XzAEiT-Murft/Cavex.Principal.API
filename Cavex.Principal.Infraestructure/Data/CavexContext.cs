using Cavex.Principal.Core.Entities;
using Cavex.Principal.Infraestructure.Config;
using Microsoft.EntityFrameworkCore;

namespace Cavex.Principal.Infraestructure.Data
{
    public class CavexContext : DbContext
    {
        public DbSet<EmpCatPais> EmpCatPaises { get; set; }
        public DbSet<EmpCatAreaLaboral> EmpCatAreasLaborales { get; set; }
        public DbSet<CatServicios> CatServicios { get; set; }
        public CavexContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmpCatPaisConfiguration).Assembly);
        }

    }
}
