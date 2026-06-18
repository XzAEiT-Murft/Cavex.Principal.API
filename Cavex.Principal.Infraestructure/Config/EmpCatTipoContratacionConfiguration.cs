using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class EmpCatTipoContratacionConfiguration : IEntityTypeConfiguration<EmpCatTipoContratacion>
    {
        public void Configure(EntityTypeBuilder<EmpCatTipoContratacion> builder)
        {
            builder.ToTable("EmpCatTipoContratacion");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrValor)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.StrDescripcion)
                .HasMaxLength(450);
        }
    }
}