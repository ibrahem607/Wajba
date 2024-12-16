global using Microsoft.Extensions.Localization;
global using Wajba.Localization;
global using Volo.Abp.DependencyInjection;
global using Volo.Abp.Ui.Branding;

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
