using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehCatMarcaVehiculoConfiguration : IEntityTypeConfiguration<VehCatMarcaVehiculo>
    {
        public void Configure(EntityTypeBuilder<VehCatMarcaVehiculo> builder)
        {
            builder.ToTable("VehCatMarcaVehiculo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrValor)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.StrDescripcion)
                .HasMaxLength(500);
        }
    }
}
