global using System.Threading.Tasks;

namespace Wajba.Data;

public interface IWajbaDbSchemaMigrator
{
    Task MigrateAsync();
}
