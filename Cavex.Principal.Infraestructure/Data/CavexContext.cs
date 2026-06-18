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
        public DbSet<CatStatus> CatStatus { get; set; }
        public DbSet<CatSucursales> CatSucursales { get; set; }

        public DbSet<EmpHistorialArea> EmpHistorialAreas { get; set; }
        public DbSet<EmpExperiencia> EmpExperiencias { get; set; }
        public DbSet<EmpCondicionesLaborales> EmpCondicionesLaborales { get; set; }
        public DbSet<EmpTelefono> EmpTelefonos { get; set; }
        public DbSet<EmpDatosAcademicos> EmpDatosAcademicos { get; set; }
        public DbSet<EmpCatTipoContratacion> EmpCatTiposContratacion { get; set; }
        public DbSet<EmpDireccion> EmpDirecciones { get; set; }
        public DbSet<EmpCatColonia> EmpCatColonias { get; set; }
        public DbSet<EmpReferenciasPersonales> EmpReferenciasPersonales { get; set; }
        public DbSet<EmpEmpleado> EmpEmpleados { get; set; }
        public DbSet<EmpDocumentosLaborales> EmpDocumentosLaborales { get; set; }
        public DbSet<EmpCatGenero> EmpCatGeneros { get; set; }
        public DbSet<EmpCatNacionalidad> EmpCatNacionalidades { get; set; }
        public DbSet<EmpCatMunicipio> EmpCatMunicipios { get; set; }
        public DbSet<EmpCatEstadoCivil> EmpCatEstadosCiviles { get; set; }
        public DbSet<EmpCatEntidadFederativa> EmpCatEntidadesFederativas { get; set; }


        public DbSet<EmpCatGenero> EmpCatGeneros { get; set; }
        public DbSet<EmpCatNacionalidad> EmpCatNacionalidades { get; set; }
        public DbSet<EmpCatMunicipio> EmpCatMunicipios { get; set; }
        public DbSet<EmpCatEntidadFederativa> EmpCatEntidadesFederativas { get; set; }

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
