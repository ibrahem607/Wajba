using Microsoft.Extensions.Localization;
using Wajba.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Wajba;

[Dependency(ReplaceServices = true)]
public class WajbaBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<WajbaResource> _localizer;

    public WajbaBrandingProvider(IStringLocalizer<WajbaResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
