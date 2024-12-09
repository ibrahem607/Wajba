using Volo.Abp.Modularity;

namespace Wajba;

[DependsOn(
    typeof(WajbaDomainModule),
    typeof(WajbaTestBaseModule)
)]
public class WajbaDomainTestModule : AbpModule
{

}
