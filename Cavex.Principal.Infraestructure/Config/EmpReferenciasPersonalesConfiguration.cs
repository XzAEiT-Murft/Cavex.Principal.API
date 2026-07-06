using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class EmpReferenciasPersonalesConfiguration : IEntityTypeConfiguration<EmpReferenciasPersonales>
    {
        public void Configure(EntityTypeBuilder<EmpReferenciasPersonales> builder)
        {
            builder.ToTable("EmpReferenciasPersonales");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrNombreCompleto)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.StrParentezco)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.BigTelefono)
                .IsRequired();

            builder.HasOne(x => x.EmpEmpleado)
                .WithMany(x => x.EmpReferenciasPersonales)
                .HasForeignKey(x => x.IdEmpEmpleado)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
