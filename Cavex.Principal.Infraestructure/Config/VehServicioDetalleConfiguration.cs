using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehServicioDetalleConfiguration : IEntityTypeConfiguration<VehServicioDetalle>
    {
        public void Configure(EntityTypeBuilder<VehServicioDetalle> builder)
        {
            builder.ToTable("VehServicioDetalle");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.MnyCostoManoObra)
                .HasColumnType("money");

            builder.Property(x => x.MnyCostoRefacciones)
                .HasColumnType("money");

            builder.Property(x => x.MnyCostoTotal)
                .HasColumnType("money")
                .HasComputedColumnSql("[mnyCostoManoObra]+[mnyCostoRefacciones]", stored: false);

            builder.Property(x => x.DteFechaFin)
                .HasColumnType("datetime");

            builder.Property(x => x.DateProximoServicioFecha)
                .HasColumnType("date");

            builder.Property(x => x.StrUrlComprobantePago)
                .HasMaxLength(2048);

            builder.Property(x => x.StrDescripcion)
                .HasMaxLength(500);

            builder.HasOne(x => x.VehCatTipoServicio)
                .WithMany(x => x.VehServiciosDetalle)
                .HasForeignKey(x => x.IdVehCatTipoServicio)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatFormaPago)
                .WithMany(x => x.VehServiciosDetalle)
                .HasForeignKey(x => x.IdVehCatFormaPago)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
