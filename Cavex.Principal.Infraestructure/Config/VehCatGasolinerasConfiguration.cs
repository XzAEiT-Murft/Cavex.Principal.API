using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehCatGasolinerasConfiguration : IEntityTypeConfiguration<VehCatGasolineras>
    {
        public void Configure(EntityTypeBuilder<VehCatGasolineras> builder)
        {
            builder.ToTable("VehCatGasolineras");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrValor)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.StrDescripcion)
                .HasMaxLength(500);

            builder.Property(x => x.IdVehCatStatus)
                .IsRequired()
                .HasDefaultValue(1);
        }
    }
}
