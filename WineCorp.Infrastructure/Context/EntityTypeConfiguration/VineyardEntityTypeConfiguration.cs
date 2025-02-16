using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineCorp.Dom.Entities;

namespace WineCorp.Infrastructure.Context
{
    public class VineyardEntityTypeConfiguration : IEntityTypeConfiguration<Vineyard>
    {
        public void Configure(EntityTypeBuilder<Vineyard> builder)
        {
            _ = builder.ToTable("Vineyards");
            _ = builder.HasKey(v => v.Id);
            _ = builder.Property(v => v.Name).IsRequired().HasMaxLength(100);

            _ = builder.HasData(
            new Vineyard { Id = 1, Name = "Viña Esmeralda" },
            new Vineyard { Id = 2, Name = "Bodegas Bilbaínas" }
        );

        }
    }
}