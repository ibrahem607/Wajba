using Volo.Abp.Modularity;

namespace Wajba;

/* Inherit from this class for your domain layer tests. */
public abstract class WajbaDomainTestBase<TStartupModule> : WajbaTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
