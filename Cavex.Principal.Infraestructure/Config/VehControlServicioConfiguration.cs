using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehControlServicioConfiguration : IEntityTypeConfiguration<VehControlServicio>
    {
        public void Configure(EntityTypeBuilder<VehControlServicio> builder)
        {
            builder.ToTable("VehControlServicio");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrDescripcion)
                .HasMaxLength(500);

            builder.Property(x => x.DteFechaInicio)
                .HasColumnType("datetime");

            builder.Property(x => x.BigKilometrajeActual)
                .HasColumnType("bigint");

            builder.HasOne(x => x.VehCatResponsableServicio)
                .WithMany(x => x.VehControlesServicio)
                .HasForeignKey(x => x.IdVehCatResponsableServicio)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatStatus)
                .WithMany(x => x.VehControlesServicio)
                .HasForeignKey(x => x.IdVehCatStatus)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.EmpEmpleado)
                .WithMany(x => x.VehControlesServicio)
                .HasForeignKey(x => x.IdEmpEmpleado)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatTaller)
                .WithMany(x => x.VehControlesServicio)
                .HasForeignKey(x => x.IdVehCatTaller)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehDatosGenerales)
                .WithMany(x => x.VehControlesServicio)
                .HasForeignKey(x => x.IdVehDatosGenerales)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehServicioDetalle)
                .WithMany(x => x.VehControlesServicio)
                .HasForeignKey(x => x.IdVehServicioDetalle)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
