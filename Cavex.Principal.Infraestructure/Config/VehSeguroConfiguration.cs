using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehSeguroConfiguration : IEntityTypeConfiguration<VehSeguro>
    {
        public void Configure(EntityTypeBuilder<VehSeguro> builder)
        {
            builder.ToTable("VehSeguro");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrNumeroPoliza)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.MnyMontoCoberura)
                .HasColumnType("money");

            builder.Property(x => x.MnyMontoPagado)
                .HasColumnType("money");

            builder.Property(x => x.StrUrlComprobantePago)
                .HasMaxLength(2048);

            builder.Property(x => x.StrUrlPolizaSeguro)
                .HasMaxLength(2048);

            builder.HasOne(x => x.VehCatAseguradora)
                .WithMany(x => x.VehSeguros)
                .HasForeignKey(x => x.IdVehCatAseguradora)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatStatus)
                .WithMany(x => x.VehSeguros)
                .HasForeignKey(x => x.IdVehCatStatus)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatTipoCobertura)
                .WithMany(x => x.VehSeguros)
                .HasForeignKey(x => x.IdVehCatTipoCobertura)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehDatosGenerales)
                .WithMany(x => x.VehSeguros)
                .HasForeignKey(x => x.IdVehDatosGenerales)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehFormaPago)
                .WithMany(x => x.VehSeguros)
                .HasForeignKey(x => x.IdVehFormaPago)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
