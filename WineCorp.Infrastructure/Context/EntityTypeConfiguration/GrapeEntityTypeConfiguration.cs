using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineCorp.Dom.Entities;

namespace WineCorp.Infrastructure.Context
{
    public class GrapeEntityTypeConfiguration : IEntityTypeConfiguration<Grape>
    {
        public void Configure(EntityTypeBuilder<Grape> builder)
        {
            _ = builder.ToTable("Grapes");
            _ = builder.HasKey(g => g.Id);
            _ = builder.Property(g => g.Name).IsRequired().HasMaxLength(100);

            //Carga inicial a modo de prueba
            _ = builder.HasData(
            new Grape { Id = 1, Name = "Tempranillo" },
            new Grape { Id = 2, Name = "Albariño" },
            new Grape { Id = 3, Name = "Garnacha" }
        );
        }
    }
}