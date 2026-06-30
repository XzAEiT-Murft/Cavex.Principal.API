using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehPermisoTransporteConfiguration : IEntityTypeConfiguration<VehPermisoTransporte>
    {
        public void Configure(EntityTypeBuilder<VehPermisoTransporte> builder)
        {
            builder.ToTable("VehPermisoTransporte");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrNumeroPermiso)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.StrAutoridad)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.MnyMontoPagado)
                .HasColumnType("money");

            builder.Property(x => x.StrUrlComprobantePago)
                .HasMaxLength(2048);

            builder.Property(x => x.StrUrlPermisoTransporte)
                .HasMaxLength(2048);

            builder.HasOne(x => x.VehCatStatus)
                .WithMany(x => x.VehPermisosTransporte)
                .HasForeignKey(x => x.IdVehCatStatus)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatTipoPermiso)
                .WithMany(x => x.VehPermisosTransporte)
                .HasForeignKey(x => x.IdVehCatTipoPermiso)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehDatosGenerales)
                .WithMany(x => x.VehPermisosTransporte)
                .HasForeignKey(x => x.IdVehDatosGenerales)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehFormaPago)
                .WithMany(x => x.VehPermisosTransporte)
                .HasForeignKey(x => x.IdVehFormaPago)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
