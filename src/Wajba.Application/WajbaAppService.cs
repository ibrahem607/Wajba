global using Wajba.Localization;

namespace Wajba;

/* Inherit your application services from this class.
 */
public abstract class WajbaAppService : ApplicationService
{
    protected WajbaAppService()
    {
        LocalizationResource = typeof(WajbaResource);
    }
}
