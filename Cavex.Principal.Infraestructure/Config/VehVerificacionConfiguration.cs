using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehVerificacionConfiguration : IEntityTypeConfiguration<VehVerificacion>
    {
        public void Configure(EntityTypeBuilder<VehVerificacion> builder)
        {
            builder.ToTable("VehVerificacion");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrFolioVerificacion)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.StrCentroVerificacion)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.StrSemestre)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(x => x.VehCatHolograma)
                .WithMany(x => x.VehVerificaciones)
                .HasForeignKey(x => x.IdVehCatHolograma)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatStatus)
                .WithMany(x => x.VehVerificaciones)
                .HasForeignKey(x => x.IdVehCatStatus)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehDatosGenerales)
                .WithMany(x => x.VehVerificaciones)
                .HasForeignKey(x => x.IdVehDatosGenerales)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
