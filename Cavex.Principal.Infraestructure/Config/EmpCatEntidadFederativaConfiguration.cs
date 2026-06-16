using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class EmpCatEntidadFederativaConfiguration : IEntityTypeConfiguration<EmpCatEntidadFederativa>
    {
        public void Configure(EntityTypeBuilder<EmpCatEntidadFederativa> builder)
        {
            builder.ToTable("EmpCatEntidadFederativa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.StrValor)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.StrDescripcion)
                .HasMaxLength(450);

            builder.Property(x => x.IdEmpCatPais)
                .IsRequired();

            builder.HasOne(x => x.EmpCatPais)
                .WithMany(x => x.EmpCatEntidadesFederativas)
                .HasForeignKey(x => x.IdEmpCatPais);
        }
    }
}