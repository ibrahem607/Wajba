using Volo.Abp.Modularity;

namespace Wajba;

[DependsOn(
    typeof(WajbaApplicationModule),
    typeof(WajbaDomainTestModule)
)]
public class WajbaApplicationTestModule : AbpModule
{

}
