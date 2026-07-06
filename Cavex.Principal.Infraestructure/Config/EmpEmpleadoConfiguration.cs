using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class EmpEmpleadoConfiguration : IEntityTypeConfiguration<EmpEmpleado>
    {
        public void Configure(EntityTypeBuilder<EmpEmpleado> builder)
        {
            builder.ToTable("EmpEmpleado");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrNombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.StrApellidoPaterno)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.StrApellidoMaterno)
                .HasMaxLength(100);

            builder.Property(x => x.StrRfc)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.StrCurp)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.StrCorreoElectronico)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.BigNss)
                .IsRequired();

            builder.HasOne(x => x.EmpCatGenero)
                .WithMany(x => x.EmpEmpleados)
                .HasForeignKey(x => x.IdEmpCatGenero)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.EmpCatEstadoCivil)
                .WithMany(x => x.EmpEmpleados)
                .HasForeignKey(x => x.IdEmpCatEstadoCivil)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.EmpCatNacionalidad)
                .WithMany(x => x.EmpEmpleados)
                .HasForeignKey(x => x.IdEmpCatNacionalidad)
                .OnDelete(DeleteBehavior.Restrict);

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

            builder.HasOne(x => x.CatStatus)
                .WithMany(x => x.EmpEmpleados)
                .HasForeignKey(x => x.IdCatStatus)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

