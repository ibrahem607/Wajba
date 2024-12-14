global using Microsoft.Extensions.DependencyInjection;
global using System;
global using System.Threading.Tasks;
global using Volo.Abp.DependencyInjection;
global using Wajba.Data;

namespace Wajba.EntityFrameworkCore;

public class EntityFrameworkCoreWajbaDbSchemaMigrator
    : IWajbaDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreWajbaDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        await _serviceProvider
            .GetRequiredService<WajbaDbContext>()
            .Database
            .MigrateAsync();
    }
}
