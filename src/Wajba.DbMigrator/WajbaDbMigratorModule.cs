using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Wajba.EntityFrameworkCore;

namespace Wajba.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(WajbaEntityFrameworkCoreModule),
    typeof(WajbaApplicationContractsModule)
    )]
public class WajbaDbMigratorModule : AbpModule
{
}
