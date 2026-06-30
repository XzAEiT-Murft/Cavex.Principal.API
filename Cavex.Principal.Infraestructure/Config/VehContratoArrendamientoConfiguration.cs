using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehContratoArrendamientoConfiguration : IEntityTypeConfiguration<VehContratoArrendamiento>
    {
        public void Configure(EntityTypeBuilder<VehContratoArrendamiento> builder)
        {
            builder.ToTable("VehContratoArrendamiento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrNumeroContrato)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.MnyMontoPagado)
                .HasColumnType("money");

            builder.Property(x => x.StrUrlComprobantePago)
                .HasMaxLength(2048);

            builder.Property(x => x.StrPeriodoPago)
                .HasMaxLength(50);

            builder.Property(x => x.StrUrlContratoArrendamiento)
                .HasMaxLength(2048);

            builder.HasOne(x => x.VehCatArrendatario)
                .WithMany(x => x.VehContratosArrendamiento)
                .HasForeignKey(x => x.IdVehCatArrendatario)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatStatus)
                .WithMany(x => x.VehContratosArrendamiento)
                .HasForeignKey(x => x.IdVehCatStatus)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehDatosGenerales)
                .WithMany(x => x.VehContratosArrendamiento)
                .HasForeignKey(x => x.IdVehDatosGenerales)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehFormaPago)
                .WithMany(x => x.VehContratosArrendamiento)
                .HasForeignKey(x => x.IdVehFormaPago)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
