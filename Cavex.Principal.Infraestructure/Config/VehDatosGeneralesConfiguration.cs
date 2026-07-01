using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehDatosGeneralesConfiguration : IEntityTypeConfiguration<VehDatosGenerales>
    {
        public void Configure(EntityTypeBuilder<VehDatosGenerales> builder)
        {
            builder.ToTable("VehDatosGenerales");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrNumSerie)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.StrModelo)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.StrVersion)
                .HasMaxLength(250);

            builder.Property(x => x.StrPlaca)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.DecKilometrajeActual)
                .HasColumnType("decimal(18,0)");

            builder.Property(x => x.StrUrlFoto)
                .HasMaxLength(2048);

            builder.Property(x => x.StrObservaciones)
                .HasMaxLength(500);

            builder.Property(x => x.StrMotor)
                .HasMaxLength(500);

            builder.HasOne(x => x.VehCatCapacidad)
                .WithMany(x => x.VehDatosGenerales)
                .HasForeignKey(x => x.IdVehCatCapacidad)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatColor)
                .WithMany(x => x.VehDatosGenerales)
                .HasForeignKey(x => x.IdVehCatColor)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatMarcaVehiculo)
                .WithMany(x => x.VehDatosGenerales)
                .HasForeignKey(x => x.IdVehCatMarcaVehiculo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatStatus)
                .WithMany(x => x.VehDatosGenerales)
                .HasForeignKey(x => x.IdVehCatStatus)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatTipoCombustible)
                .WithMany(x => x.VehDatosGenerales)
                .HasForeignKey(x => x.IdVehCatTipoCombustible)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatTipoVehiculo)
                .WithMany(x => x.VehDatosGenerales)
                .HasForeignKey(x => x.IdVehCatTipoVehiculo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatTransmision)
                .WithMany(x => x.VehDatosGenerales)
                .HasForeignKey(x => x.IdVehCatTransmision)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
