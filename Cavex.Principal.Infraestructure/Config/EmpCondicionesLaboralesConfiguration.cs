
using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class EmpCondicionesLaboralesConfiguration : IEntityTypeConfiguration<EmpCondicionesLaborales>
    {
        public void Configure(EntityTypeBuilder<EmpCondicionesLaborales> builder)
        {
            builder.ToTable("EmpCondicionesLaborales");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.MnySueldoMensual)
                .HasColumnType("money");
        }
    }
}