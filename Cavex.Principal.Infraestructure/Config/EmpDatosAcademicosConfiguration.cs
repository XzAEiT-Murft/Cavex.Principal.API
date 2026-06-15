using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class EmpDatosAcademicosConfiguration : IEntityTypeConfiguration<EmpDatosAcademicos>
    {
        public void Configure(EntityTypeBuilder<EmpDatosAcademicos> builder)
        {
            builder.ToTable("EmpDatosAcademicos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrNivelEstudios)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.StrInstitucion)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.StrCarrera)
                .HasMaxLength(200);

            builder.Property(x => x.StrEstatus)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}