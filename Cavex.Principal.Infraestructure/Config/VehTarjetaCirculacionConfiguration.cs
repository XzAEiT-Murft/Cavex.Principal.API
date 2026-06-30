using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehTarjetaCirculacionConfiguration : IEntityTypeConfiguration<VehTarjetaCirculacion>
    {
        public void Configure(EntityTypeBuilder<VehTarjetaCirculacion> builder)
        {
            builder.ToTable("VehTarjetaCirculacion");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrNumeroTarjeta)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.MnyMontoPagado)
                .HasColumnType("money");

            builder.Property(x => x.StrUrlComprobantePago)
                .HasMaxLength(2048);

            builder.Property(x => x.StrUrlTarjeta)
                .HasMaxLength(2048);

            builder.HasOne(x => x.EmpCatEntidadFederativa)
                .WithMany()
                .HasForeignKey(x => x.IdEmpCatEntidadFederativa)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatStatus)
                .WithMany(x => x.VehTarjetasCirculacion)
                .HasForeignKey(x => x.IdVehCatStatus)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehDatosGenerales)
                .WithMany(x => x.VehTarjetasCirculacion)
                .HasForeignKey(x => x.IdVehDatosGenerales)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehFormaPago)
                .WithMany(x => x.VehTarjetasCirculacion)
                .HasForeignKey(x => x.IdVehFormaPago)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
