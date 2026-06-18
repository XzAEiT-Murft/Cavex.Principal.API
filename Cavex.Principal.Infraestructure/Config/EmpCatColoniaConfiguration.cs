using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class EmpCatColoniaConfiguration : IEntityTypeConfiguration<EmpCatColonia>
    {
        public void Configure(EntityTypeBuilder<EmpCatColonia> builder)
        {
            builder.ToTable("EmpCatColonia");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrValor)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.StrDescripcion)
                .HasMaxLength(450);

            builder.Property(x => x.StrTipoAsentamiento)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(x => x.EmpCatMunicipio)
                .WithMany(x => x.EmpCatColonias)
                .HasForeignKey(x => x.IntEmpCatMunicipio)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
