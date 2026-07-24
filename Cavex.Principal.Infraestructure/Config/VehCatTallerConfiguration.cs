using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehCatTallerConfiguration : IEntityTypeConfiguration<VehCatTaller>
    {
        public void Configure(EntityTypeBuilder<VehCatTaller> builder)
        {
            builder.ToTable("VehCatTaller");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrValor)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.StrDescripcion)
                .HasMaxLength(500);

            builder.HasOne(x => x.CatStatus)
                .WithMany()
                .HasForeignKey(x => x.IdCatStatus)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
