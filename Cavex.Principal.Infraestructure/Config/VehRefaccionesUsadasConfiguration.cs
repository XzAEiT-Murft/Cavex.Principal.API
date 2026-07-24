using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class VehRefaccionesUsadasConfiguration : IEntityTypeConfiguration<VehRefaccionesUsadas>
    {
        public void Configure(EntityTypeBuilder<VehRefaccionesUsadas> builder)
        {
            builder.ToTable("VehRefaccionesUsadas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.VehCatRefacciones)
                .WithMany(x => x.VehRefaccionesUsadas)
                .HasForeignKey(x => x.IdVehCatRefacciones)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehServicioDetalle)
                .WithMany(x => x.VehRefaccionesUsadas)
                .HasForeignKey(x => x.IdVehServicioDetalle)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
