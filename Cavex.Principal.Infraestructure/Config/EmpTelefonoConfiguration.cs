using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class EmpTelefonoConfiguration : IEntityTypeConfiguration<EmpTelefono>
    {
        public void Configure(EntityTypeBuilder<EmpTelefono> builder)
        {
            builder.ToTable("EmpTelefono");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrNumeroFijo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.StrNumeroCelular)
                .HasMaxLength(50);

            builder.HasOne(x => x.EmpEmpleado)
                .WithMany(x => x.EmpTelefonos)
                .HasForeignKey(x => x.IdEmpEmpleado)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
