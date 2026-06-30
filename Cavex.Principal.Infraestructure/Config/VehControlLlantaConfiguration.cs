using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehControlLlantaConfiguration : IEntityTypeConfiguration<VehControlLlanta>
    {
        public void Configure(EntityTypeBuilder<VehControlLlanta> builder)
        {
            builder.ToTable("VehControlLlanta");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrModelo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.StrMedida)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.MnyCosto)
                .HasColumnType("money");

            builder.Property(x => x.DecKilometrajeActual)
                .HasColumnType("decimal(18,0)");

            builder.Property(x => x.StrUrlEvidencia)
                .HasMaxLength(2048);

            builder.HasOne(x => x.VehCatMarcaLlanta)
                .WithMany(x => x.VehControlesLlanta)
                .HasForeignKey(x => x.IdVehCatMarcaLlanta)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatPosicionLlanta)
                .WithMany(x => x.VehControlesLlanta)
                .HasForeignKey(x => x.IdVehCatPosicionLlanta)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatStatus)
                .WithMany(x => x.VehControlesLlanta)
                .HasForeignKey(x => x.IdVehCatStatus)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehDatosGenerales)
                .WithMany(x => x.VehControlesLlanta)
                .HasForeignKey(x => x.IdVehDatosGenerales)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
