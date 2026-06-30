using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehControlGasolinaConfiguration : IEntityTypeConfiguration<VehControlGasolina>
    {
        public void Configure(EntityTypeBuilder<VehControlGasolina> builder)
        {
            builder.ToTable("VehControlGasolina");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.MnyMontoPagado)
                .HasColumnType("money");

            builder.Property(x => x.MnyPrecioLitro)
                .HasColumnType("money");

            builder.Property(x => x.DecKilometrajeActual)
                .HasColumnType("decimal(18,0)");

            builder.Property(x => x.StrUrlComprobantePago)
                .HasMaxLength(2048);

            builder.HasOne(x => x.EmpEmpleado)
                .WithMany()
                .HasForeignKey(x => x.IdEmpEmpleado)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehCatGasolineras)
                .WithMany(x => x.VehControlesGasolina)
                .HasForeignKey(x => x.IdVehCatGasolineras)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehDatosGenerales)
                .WithMany(x => x.VehControlesGasolina)
                .HasForeignKey(x => x.IdVehDatosGenerales)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehFormaPago)
                .WithMany(x => x.VehControlesGasolina)
                .HasForeignKey(x => x.IdVehFormaPago)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
