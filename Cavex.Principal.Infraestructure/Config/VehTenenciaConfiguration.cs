using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehTenenciaConfiguration : IEntityTypeConfiguration<VehTenencia>
    {
        public void Configure(EntityTypeBuilder<VehTenencia> builder)
        {
            builder.ToTable("VehTenencia");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.MnyMontoPagado)
                .HasColumnType("money");

            builder.Property(x => x.StrFolioPago)
                .HasMaxLength(100);

            builder.Property(x => x.StrUrlComprobantePago)
                .HasMaxLength(2048);

            builder.Property(x => x.StrUrlFormatoTenencia)
                .HasMaxLength(2048);

            builder.HasOne(x => x.VehCatFormaPago)
                .WithMany(x => x.VehTenencias)
                .HasForeignKey(x => x.IdVehCatFormaPago)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatStatus)
                .WithMany(x => x.VehTenencias)
                .HasForeignKey(x => x.IdVehCatStatus)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehDatosGenerales)
                .WithMany(x => x.VehTenencias)
                .HasForeignKey(x => x.IdVehDatosGenerales)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
