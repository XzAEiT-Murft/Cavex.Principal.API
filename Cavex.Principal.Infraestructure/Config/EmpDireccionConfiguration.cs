using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class EmpDireccionConfiguration : IEntityTypeConfiguration<EmpDireccion>
    {
        public void Configure(EntityTypeBuilder<EmpDireccion> builder)
        {
            builder.ToTable("EmpDireccion");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.EmpCatColonia)
                .WithMany(x => x.EmpDirecciones)
                .HasForeignKey(x => x.IdEmpCatColonia)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}