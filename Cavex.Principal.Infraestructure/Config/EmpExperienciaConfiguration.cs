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
    public class EmpExperienciaConfiguration : IEntityTypeConfiguration<EmpExperiencia>
    {
        public void Configure(EntityTypeBuilder<EmpExperiencia> builder)
        {
            builder.ToTable("EmpExperiencia");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StrEmpresa)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.StrPuesto)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.StrArea)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.MnySueldo)
                .HasColumnType("money");

            builder.Property(x => x.StrMotivoSalida)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(x => x.EmpEmpleado)
                .WithMany(x => x.EmpExperiencias)
                .HasForeignKey(x => x.IdEmpEmpleado)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
