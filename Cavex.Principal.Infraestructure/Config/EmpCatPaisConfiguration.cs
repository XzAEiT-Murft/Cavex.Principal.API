using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cavex.Principal.Infraestructure.Config
{
    public class EmpCatPaisConfiguration : IEntityTypeConfiguration<EmpCatPais>
    {
        public void Configure(EntityTypeBuilder<EmpCatPais> builder)
        {
            builder.Property(x => x.StrValor).IsRequired();
            builder.Property(x => x.StrDescripcion);
        }
    }
}
