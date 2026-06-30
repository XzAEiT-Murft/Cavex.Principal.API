using Cavex.Principal.Core.Entities;
using Cavex.Principal.Infraestructure.Config;
using Microsoft.EntityFrameworkCore;

namespace Cavex.Principal.Infraestructure.Data
{
    /// <summary>
    /// Contexto principal de EF Core para la base de datos CavexDb.
    /// </summary>
    public class CavexContext : DbContext
    {
        // DbSet expone cada tabla al repositorio generico y a las consultas de EF Core.
        public DbSet<CatServicios> CatServicioss { get; set; }
        public DbSet<CatStatus> CatStatuss { get; set; }
        public DbSet<CatSucursales> CatSucursaless { get; set; }
        public DbSet<EmpCatAreaLaboral> EmpCatAreaLaborals { get; set; }
        public DbSet<EmpCatColonia> EmpCatColonias { get; set; }
        public DbSet<EmpCatEntidadFederativa> EmpCatEntidadFederativas { get; set; }
        public DbSet<EmpCatEstadoCivil> EmpCatEstadoCivils { get; set; }
        public DbSet<EmpCatGenero> EmpCatGeneros { get; set; }
        public DbSet<EmpCatMunicipio> EmpCatMunicipios { get; set; }
        public DbSet<EmpCatNacionalidad> EmpCatNacionalidads { get; set; }
        public DbSet<EmpCatPais> EmpCatPaiss { get; set; }
        public DbSet<EmpCatTipoContratacion> EmpCatTipoContratacions { get; set; }
        public DbSet<EmpCondicionesLaborales> EmpCondicionesLaboraless { get; set; }
        public DbSet<EmpDatosAcademicos> EmpDatosAcademicoss { get; set; }
        public DbSet<EmpDireccion> EmpDireccions { get; set; }
        public DbSet<EmpDocumentosLaborales> EmpDocumentosLaboraless { get; set; }
        public DbSet<EmpEmpleado> EmpEmpleados { get; set; }
        public DbSet<EmpExperiencia> EmpExperiencias { get; set; }
        public DbSet<EmpHistorialArea> EmpHistorialAreas { get; set; }
        public DbSet<EmpReferenciasPersonales> EmpReferenciasPersonaless { get; set; }
        public DbSet<EmpTelefono> EmpTelefonos { get; set; }
        public DbSet<VehAsignacionVehiculos> VehAsignacionesVehiculos { get; set; }
        public DbSet<VehCatArrendatario> VehCatArrendatarios { get; set; }
        public DbSet<VehCatAseguradora> VehCatAseguradoras { get; set; }
        public DbSet<VehCatCapacidad> VehCatCapacidades { get; set; }
        public DbSet<VehCatColor> VehCatColores { get; set; }
        public DbSet<VehCatFormaPago> VehCatFormaPagos { get; set; }
        public DbSet<VehCatGasolineras> VehCatGasolinerass { get; set; }
        public DbSet<VehCatHolograma> VehCatHologramas { get; set; }
        public DbSet<VehCatMarcaLlanta> VehCatMarcaLlantas { get; set; }
        public DbSet<VehCatMarcaVehiculo> VehCatMarcaVehiculos { get; set; }
        public DbSet<VehCatPosicionLlanta> VehCatPosicionLlantas { get; set; }
        public DbSet<VehCatRefacciones> VehCatRefaccioness { get; set; }
        public DbSet<VehCatResponsableServicio> VehCatResponsableServicios { get; set; }
        public DbSet<VehCatStatus> VehCatStatus { get; set; }
        public DbSet<VehCatTaller> VehCatTallers { get; set; }
        public DbSet<VehCatTipoCobertura> VehCatTipoCoberturas { get; set; }
        public DbSet<VehCatTipoCombustible> VehCatTipoCombustibles { get; set; }
        public DbSet<VehCatTipoPermiso> VehCatTipoPermisos { get; set; }
        public DbSet<VehCatTipoServicio> VehCatTipoServicios { get; set; }
        public DbSet<VehCatTipoVehiculo> VehCatTipoVehiculos { get; set; }
        public DbSet<VehContratoArrendamiento> VehContratoArrendamientos { get; set; }
        public DbSet<VehControlGasolina> VehControlGasolinas { get; set; }
        public DbSet<VehControlLlanta> VehControlLlantas { get; set; }
        public DbSet<VehControlServicio> VehControlServicios { get; set; }
        public DbSet<VehDaniosAccidentes> VehDaniosAccidentess { get; set; }
        public DbSet<VehDatosGenerales> VehDatosGenerales { get; set; }
        public DbSet<VehDocumentosVehiculo> VehDocumentosVehiculo { get; set; }
        public DbSet<VehInfracciones> VehInfraccioness { get; set; }
        public DbSet<VehPermisoTransporte> VehPermisoTransportes { get; set; }
        public DbSet<VehPlacas> VehPlacass { get; set; }
        public DbSet<VehRefaccionesUsadas> VehRefaccionesUsadas { get; set; }
        public DbSet<VehRevistaVehicular> VehRevistaVehiculars { get; set; }
        public DbSet<VehSeguro> VehSeguros { get; set; }
        public DbSet<VehTarjetaCirculacion> VehTarjetaCirculacions { get; set; }
        public DbSet<VehTenencia> VehTenencias { get; set; }
        public DbSet<VehVerificacion> VehVerificacions { get; set; }

        public CavexContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica automaticamente todas las clases IEntityTypeConfiguration del ensamblado.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmpCatPaisConfiguration).Assembly);
        }
    }
}
