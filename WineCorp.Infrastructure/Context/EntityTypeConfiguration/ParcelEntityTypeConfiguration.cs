using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineCorp.Dom.Entities;

namespace WineCorp.Infrastructure.Context
{
    public class ParcelEntityTypeConfiguration : IEntityTypeConfiguration<Parcel>
    {
        public void Configure(EntityTypeBuilder<Parcel> builder)
        {
            _ = builder.ToTable("Parcels");
            _ = builder.HasKey(p => p.Id);
            _ = builder.Property(p => p.YearPlanted).IsRequired();
            _ = builder.Property(p => p.Area).IsRequired().HasDefaultValue(1);
            _ = builder.HasOne(p => p.Manager).WithMany(m => m.Parcels).HasForeignKey(p => p.ManagerId);
            _ = builder.HasOne(p => p.Vineyard).WithMany(v => v.Parcels).HasForeignKey(p => p.VineyardId);
            _ = builder.HasOne(p => p.Grape).WithMany(g => g.Parcels).HasForeignKey(p => p.GrapeId);

            _ = builder.HasData(
            new Parcel { Id = 1, ManagerId = 1, VineyardId = 1, GrapeId = 1, YearPlanted = 2019, Area = 1500 },
            new Parcel { Id = 2, ManagerId = 2, VineyardId = 2, GrapeId = 2, YearPlanted = 2021, Area = 9000 },
            new Parcel { Id = 3, ManagerId = 3, VineyardId = 1, GrapeId = 3, YearPlanted = 2020, Area = 3000 },
            new Parcel { Id = 4, ManagerId = 1, VineyardId = 2, GrapeId = 1, YearPlanted = 2020, Area = 2000 },
            new Parcel { Id = 5, ManagerId = 3, VineyardId = 2, GrapeId = 3, YearPlanted = 2021, Area = 1000 }
        );
        }
    }
}