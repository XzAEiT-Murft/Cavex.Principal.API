using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehPlacasConfiguration : IEntityTypeConfiguration<VehPlacas>
    {
        public void Configure(EntityTypeBuilder<VehPlacas> builder)
        {
            builder.ToTable("VehPlacas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrNumPlaca)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.MnyMontoPagado)
                .HasColumnType("money");

            builder.Property(x => x.StrUrlComprobantePago)
                .HasMaxLength(2048);

            builder.Property(x => x.StrUrlPlacas)
                .HasMaxLength(2048);

            builder.HasOne(x => x.EmpCatEntidadFederativa)
                .WithMany()
                .HasForeignKey(x => x.IdEmpCatEntidadFederativa)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatFormaPago)
                .WithMany(x => x.VehPlacas)
                .HasForeignKey(x => x.IdVehCatFormaPago)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatStatus)
                .WithMany(x => x.VehPlacas)
                .HasForeignKey(x => x.IdVehCatStatus)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehDatosGenerales)
                .WithMany(x => x.VehPlacas)
                .HasForeignKey(x => x.IdVehDatosGenerales)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
