global using Volo.Abp.DependencyInjection;

namespace Wajba.Data;

public class NullWajbaDbSchemaMigrator : IWajbaDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
