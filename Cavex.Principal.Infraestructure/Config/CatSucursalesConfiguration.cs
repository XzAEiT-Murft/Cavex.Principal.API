using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Infraestructure.Config
{
    public class CatSucursalesConfiguration : IEntityTypeConfiguration<CatSucursales>
    {
        public void Configure(EntityTypeBuilder<CatSucursales> builder)
        {
            builder.ToTable("CatSucursales");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrValor)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.StrDescripcion)
                .HasMaxLength(450);

            builder.HasOne(x => x.CatStatus)
                .WithMany(x => x.CatSucursales)
                .HasForeignKey(x => x.IdCatStatus)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}