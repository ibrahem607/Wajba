global using Wajba.Localization;
global using Volo.Abp.AspNetCore.Mvc;

namespace Wajba.Controllers;

/* Inherit your controllers from this class.
 */

public abstract class WajbaController : AbpControllerBase
{
    protected WajbaController()
    {
        LocalizationResource = typeof(WajbaResource);
    }
}
