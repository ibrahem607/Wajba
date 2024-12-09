using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Wajba.Data;

/* This is used if database provider does't define
 * IWajbaDbSchemaMigrator implementation.
 */
public class NullWajbaDbSchemaMigrator : IWajbaDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
