using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    /// <summary>
    /// Configuracion EF Core para el catalogo de transmisiones vehiculares.
    /// </summary>
    public class VehCatTransmisionConfiguration : IEntityTypeConfiguration<VehCatTransmision>
    {
        public void Configure(EntityTypeBuilder<VehCatTransmision> builder)
        {
            builder.ToTable("VehCatTransmision");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrValor)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.StrDescripcion)
                .HasMaxLength(500);

            builder.HasData(
                new VehCatTransmision { Id = 1, StrValor = "Manual", StrDescripcion = "Transmisión manual o estándar" },
                new VehCatTransmision { Id = 2, StrValor = "Automática", StrDescripcion = "Transmisión automática" }
            );
        }
    }
}
