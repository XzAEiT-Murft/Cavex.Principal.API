using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class EmpCatMunicipioConfiguration : IEntityTypeConfiguration<EmpCatMunicipio>
    {
        public void Configure(EntityTypeBuilder<EmpCatMunicipio> builder)
        {
            builder.ToTable("EmpCatMunicipio");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.StrValor)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.StrDescripcion)
                .HasMaxLength(450);

            builder.Property(x => x.IdEmpCatEntidadFederativa)
                .IsRequired();

            builder.HasOne(x => x.EmpCatEntidadFederativa)
                .WithMany(x => x.EmpCatMunicipios)
                .HasForeignKey(x => x.IdEmpCatEntidadFederativa);
            
            builder.Navigation(x => x.EmpCatEntidadFederativa).AutoInclude();
        }
    }
}