using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WineCorp.Dom.Entities;

namespace WineCorp.Infrastructure.Context
{
    public class ManagerEntityTypeConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            _ = builder.ToTable("Managers");
            _ = builder.HasKey(m => m.Id);
            _ = builder.Property(x => x.TaxNumber).IsRequired().HasMaxLength(50);
            _ = builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            //Carga inicial a modo de prueba
            _ = builder.HasData(
            new Manager { Id = 1, TaxNumber = "132254524", Name = "Miguel Torres" },
            new Manager { Id = 2, TaxNumber = "143618668", Name = "Ana Martín" },
            new Manager { Id = 3, TaxNumber = "78903228", Name = "Carlos Ruiz" }
        );

        }
    }
}
