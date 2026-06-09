using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cavex.Principal.Core.Entities;
using Cavex.Principal.Infraestructure.Config;
using Cavex.Principal.Infraestructure.Data;
{
    
}
namespace Cavex.Principal.Infraestructure.Data
{
    public class CavexContext : DbContext
    {
        public DbSet<EmpCatPais> EmpCatPaises { get; set; }

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
