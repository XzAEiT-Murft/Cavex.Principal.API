using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class EmpEmpleadoConfiguration : IEntityTypeConfiguration<EmpEmpleado>
    {
        public void Configure(EntityTypeBuilder<EmpEmpleado> builder)
        {
            builder.HasOne(x => x.EmpDireccion)
                .WithMany(x => x.EmpEmpleados)
                .HasForeignKey(x => x.IdEmpDireccion)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.EmpCondicionesLaborales)
                .WithMany(x => x.EmpEmpleados)
                .HasForeignKey(x => x.IdEmpCondicionesLaborales)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x=>x.EmpDatosAcademicos)
                .WithMany(x=>x.EmpEmpleados)
                .HasForeignKey(x=> x.IdEmpDatosAcademicos)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.EmpDocumentosLaborales)
                .WithMany(x => x.EmpEmpleados)
                .HasForeignKey(x => x.IdEmpDocumentosLaborales)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.EmpCatTipoContratacion)
                .WithMany(x => x.EmpEmpleados)
                .HasForeignKey(x => x.IdEmpCatTipoContratacion)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

