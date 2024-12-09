using System;
using System.Collections.Generic;
using System.Text;
using Wajba.Localization;
using Volo.Abp.Application.Services;

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
