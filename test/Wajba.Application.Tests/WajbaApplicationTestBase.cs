using Volo.Abp.Modularity;

namespace Wajba;

public abstract class WajbaApplicationTestBase<TStartupModule> : WajbaTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
