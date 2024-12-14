global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.Extensions.Configuration;
global using System.IO;

namespace Wajba.EntityFrameworkCore;

public class WajbaDbContextFactory : IDesignTimeDbContextFactory<WajbaDbContext>
{
    public WajbaDbContext CreateDbContext(string[] args)
    {
        WajbaEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<WajbaDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new WajbaDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Wajba.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
