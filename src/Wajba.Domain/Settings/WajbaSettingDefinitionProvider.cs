global using Volo.Abp.Settings;

namespace Wajba.Settings;

public class WajbaSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(WajbaSettings.MySetting1));
    }
}
