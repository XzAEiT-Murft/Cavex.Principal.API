using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    internal class CatServiciosConfiguration : IEntityTypeConfiguration<CatServicios>
    {
        public void Configure(EntityTypeBuilder<CatServicios> builder)
        {
            builder.ToTable("CatServicios");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.StrValor)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.StrDescripcion)
                .HasMaxLength(450);

            builder.HasOne(x => x.CatStatus)
                .WithMany(x => x.CatServicios)
                .HasForeignKey(x => x.IdCatStatus)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
