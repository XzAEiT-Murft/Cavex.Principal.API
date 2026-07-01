using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class EmpDocumentosLaboralesConfiguration : IEntityTypeConfiguration<EmpDocumentosLaborales>
    {
        public void Configure(EntityTypeBuilder<EmpDocumentosLaborales> builder)
        {
            builder.ToTable("EmpDocumentosLaborales");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrUrlIdentificacionOficial)
                .IsRequired()
                .HasMaxLength(2048);

            builder.Property(x => x.StrUrlComprobanteDomicilio)
                .IsRequired()
                .HasMaxLength(2048);

            builder.Property(x => x.StrUrlCurriculumVitae)
                .IsRequired()
                .HasMaxLength(2048);

            builder.Property(x => x.StrUrlContrato)
                .IsRequired()
                .HasMaxLength(2048);

            builder.Property(x => x.StrUrlLicencia)
                .IsRequired()
                .HasMaxLength(2048);

            builder.Property(x => x.StrUrlFotoEmp)
                .IsRequired()
                .HasMaxLength(2048);
        }
    }
}
