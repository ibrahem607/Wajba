global using Volo.Abp.AuditLogging.EntityFrameworkCore;
global using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
global using Volo.Abp.Data;
global using Volo.Abp.EntityFrameworkCore;
global using Volo.Abp.EntityFrameworkCore.SqlServer;
global using Volo.Abp.FeatureManagement.EntityFrameworkCore;
global using Volo.Abp.Identity;
global using Volo.Abp.Identity.EntityFrameworkCore;
global using Volo.Abp.Modularity;
global using Volo.Abp.OpenIddict.EntityFrameworkCore;
global using Volo.Abp.PermissionManagement.EntityFrameworkCore;
global using Volo.Abp.SettingManagement.EntityFrameworkCore;
global using Volo.Abp.TenantManagement;
global using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Wajba.EntityFrameworkCore;

[DependsOn(
    typeof(WajbaDomainModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule)
    )]
public class WajbaEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        WajbaEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<WajbaDbContext>(options =>
        {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
                /* The main point to change your DBMS.
                 * See also WajbaMigrationsDbContextFactory for EF Core tooling. */
            options.UseSqlServer();
        });

    }
}
