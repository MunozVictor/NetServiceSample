using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCorp.Dom.Entities;

namespace WineCorp.Infrastructure.Context
{
    public class WineCorpDbContext : DbContext
    {
        public WineCorpDbContext(DbContextOptions<WineCorpDbContext> connection) : base(connection)
        {
        }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Grape> Grapes { get; set; }
        public DbSet<Vineyard> Vineyards { get; set; }
        public DbSet<Parcel> Parcels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfiguration(new ManagerEntityTypeConfiguration());
            _ = modelBuilder.ApplyConfiguration(new ParcelEntityTypeConfiguration());
            _ = modelBuilder.ApplyConfiguration(new VineyardEntityTypeConfiguration());
            _ = modelBuilder.ApplyConfiguration(new GrapeEntityTypeConfiguration());
        }

    }
}
