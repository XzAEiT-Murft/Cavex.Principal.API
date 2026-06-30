using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehRevistaVehicularConfiguration : IEntityTypeConfiguration<VehRevistaVehicular>
    {
        public void Configure(EntityTypeBuilder<VehRevistaVehicular> builder)
        {
            builder.ToTable("VehRevistaVehicular");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrFolioRevista)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.StrResultado)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.StrInspector)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.MnyMontoPagado)
                .HasColumnType("money");

            builder.Property(x => x.StrUrlComprobantePago)
                .HasMaxLength(2048);

            builder.Property(x => x.StrUrlRevistaVehicular)
                .HasMaxLength(2048);

            builder.HasOne(x => x.VehCatStatus)
                .WithMany(x => x.VehRevistasVehiculares)
                .HasForeignKey(x => x.IdVehCatStatus)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehDatosGenerales)
                .WithMany(x => x.VehRevistasVehiculares)
                .HasForeignKey(x => x.IdVehDatosGenerales)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehFormaPago)
                .WithMany(x => x.VehRevistasVehiculares)
                .HasForeignKey(x => x.IdVehFormaPago)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
