using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCorp.Infrastructure.Context;
using System.IO;

namespace WineCorp.Migrations
{
    public class WineCorpContextFactory : IDesignTimeDbContextFactory<WineCorpDbContext>
{
    public WineCorpDbContext CreateDbContext(string[] args)
    {
        

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        string connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'WineCorp' not found in appsettings.json");
        }

        var optionsBuilder = new DbContextOptionsBuilder<WineCorpDbContext>();
        optionsBuilder.UseSqlServer(connectionString, sqlOptions =>
            sqlOptions.MigrationsAssembly(typeof(WineCorpContextFactory).Assembly.FullName));

        return new WineCorpDbContext(optionsBuilder.Options);
    }
}
}
