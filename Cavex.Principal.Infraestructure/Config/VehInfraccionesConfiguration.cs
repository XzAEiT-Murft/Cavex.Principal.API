using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehInfraccionesConfiguration : IEntityTypeConfiguration<VehInfracciones>
    {
        public void Configure(EntityTypeBuilder<VehInfracciones> builder)
        {
            builder.ToTable("VehInfracciones");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrMotivo)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.MnyMontoPagado)
                .HasColumnType("money");

            builder.Property(x => x.StrUrlComprobantePago)
                .HasMaxLength(2048);

            builder.Property(x => x.StrObservaciones)
                .HasMaxLength(500);

            builder.HasOne(x => x.EmpEmpleado)
                .WithMany()
                .HasForeignKey(x => x.IdEmpEmpleado)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatStatus)
                .WithMany(x => x.VehInfracciones)
                .HasForeignKey(x => x.IdVehCatStatus)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehDatosGenerales)
                .WithMany(x => x.VehInfracciones)
                .HasForeignKey(x => x.IdVehDatosGenerales)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehFormaPago)
                .WithMany(x => x.VehInfracciones)
                .HasForeignKey(x => x.IdVehFormaPago)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
