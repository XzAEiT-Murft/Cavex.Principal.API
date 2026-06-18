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
    public class EmpHistorialAreaConfiguration : IEntityTypeConfiguration<EmpHistorialArea>
    {
        public void Configure(EntityTypeBuilder<EmpHistorialArea> builder)
        {
            builder.ToTable("EmpHistorialArea");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.EmpCatAreaLaboral)
                .WithMany(x => x.EmpHistorialAreas)
                .HasForeignKey(x => x.IdEmpCatAreaLaboral)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.EmpEmpleado)
                .WithMany(x => x.EmpHistorialAreas)
                .HasForeignKey(x => x.IdEmpEmpleado)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
