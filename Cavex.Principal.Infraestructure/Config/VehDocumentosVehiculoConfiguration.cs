using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehDocumentosVehiculoConfiguration : IEntityTypeConfiguration<VehDocumentosVehiculo>
    {
        public void Configure(EntityTypeBuilder<VehDocumentosVehiculo> builder)
        {
            builder.ToTable("VehDocumentosVehiculo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrUrlFactura)
                .HasMaxLength(2048);

            builder.HasOne(x => x.VehContratoArrendamiento)
                .WithMany(x => x.VehDocumentosVehiculo)
                .HasForeignKey(x => x.IdVehContratoArrendamiento)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehDatosGenerales)
                .WithMany(x => x.VehDocumentosVehiculo)
                .HasForeignKey(x => x.IdVehDatosGenerales)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehPermisoTransporte)
                .WithMany(x => x.VehDocumentosVehiculo)
                .HasForeignKey(x => x.IdVehPermisoTransporte)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehPlacas)
                .WithMany(x => x.VehDocumentosVehiculo)
                .HasForeignKey(x => x.IdVehPlacas)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehRevistaVehicular)
                .WithMany(x => x.VehDocumentosVehiculo)
                .HasForeignKey(x => x.IdVehRevistaVehicular)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehSeguro)
                .WithMany(x => x.VehDocumentosVehiculo)
                .HasForeignKey(x => x.IdVehSeguro)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehTarjetaCirculacion)
                .WithMany(x => x.VehDocumentosVehiculo)
                .HasForeignKey(x => x.IdVehTarjetaCirculacion)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehTenencia)
                .WithMany(x => x.VehDocumentosVehiculo)
                .HasForeignKey(x => x.IdVehTenencia)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehVerificacion)
                .WithMany(x => x.VehDocumentosVehiculo)
                .HasForeignKey(x => x.IdVehVerificacion)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
