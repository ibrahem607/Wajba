using Wajba.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Wajba.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(WajbaEntityFrameworkCoreModule),
    typeof(WajbaApplicationContractsModule)
    )]
public class WajbaDbMigratorModule : AbpModule
{
}
