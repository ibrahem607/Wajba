using Wajba.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Wajba.Permissions;

public class WajbaPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(WajbaPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(WajbaPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<WajbaResource>(name);
    }
}
