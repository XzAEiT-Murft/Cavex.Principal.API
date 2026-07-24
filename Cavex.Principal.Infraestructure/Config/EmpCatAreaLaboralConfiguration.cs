using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class EmpCatAreaLaboralConfiguration : IEntityTypeConfiguration<EmpCatAreaLaboral>
    {
        public void Configure(EntityTypeBuilder<EmpCatAreaLaboral> builder)
        {
            builder.ToTable("EmpCatAreaLaboral");

            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StrValor)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.StrDescripcion)
                .HasMaxLength(450);

            builder.HasOne(x => x.CatStatus)
                .WithMany()
                .HasForeignKey(x => x.IdCatStatus)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
