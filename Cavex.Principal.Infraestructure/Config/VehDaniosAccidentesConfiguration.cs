using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehDaniosAccidentesConfiguration : IEntityTypeConfiguration<VehDaniosAccidentes>
    {
        public void Configure(EntityTypeBuilder<VehDaniosAccidentes> builder)
        {
            builder.ToTable("VehDaniosAccidentes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrDescripcion)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.StrUbicacion)
                .HasMaxLength(300);

            builder.Property(x => x.MnyMontoReparacion)
                .HasColumnType("money");

            builder.Property(x => x.StrUrlEvidencia)
                .HasMaxLength(2048);

            builder.Property(x => x.StrObservaciones)
                .HasMaxLength(500);

            builder.HasOne(x => x.EmpEmpleado)
                .WithMany()
                .HasForeignKey(x => x.IdEmpEmpleado)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatStatus)
                .WithMany(x => x.VehDaniosAccidentes)
                .HasForeignKey(x => x.IdVehCatStatus)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehDatosGenerales)
                .WithMany(x => x.VehDaniosAccidentes)
                .HasForeignKey(x => x.IdVehDatosGenerales)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehSeguro)
                .WithMany(x => x.VehDaniosAccidentes)
                .HasForeignKey(x => x.IdVehSeguro)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
