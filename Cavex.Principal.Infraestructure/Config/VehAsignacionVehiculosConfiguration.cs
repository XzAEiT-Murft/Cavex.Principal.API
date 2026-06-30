using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehAsignacionVehiculosConfiguration : IEntityTypeConfiguration<VehAsignacionVehiculos>
    {
        public void Configure(EntityTypeBuilder<VehAsignacionVehiculos> builder)
        {
            builder.ToTable("VehAsignacionVehiculos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.DecKilometrajeInicial)
                .HasColumnType("decimal(18,0)");

            builder.Property(x => x.DecKilometrajeFinal)
                .HasColumnType("decimal(18,0)");

            builder.Property(x => x.DecKilometrajeTotal)
                .HasColumnType("decimal(18,0)");

            builder.HasOne(x => x.EmpEmpleado)
                .WithMany()
                .HasForeignKey(x => x.IdEmpEmpleado)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehDatosGenerales)
                .WithMany(x => x.VehAsignacionesVehiculos)
                .HasForeignKey(x => x.IdVehDatosGenerales)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
