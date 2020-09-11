using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using ITactDemo.Authorization.Roles;
using ITactDemo.Authorization.Users;
using ITactDemo.Configuration;
using ITactDemo.Localization;
using ITactDemo.MultiTenancy;
using ITactDemo.Timing;

namespace ITactDemo
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class ITactDemoCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
           // Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            ITactDemoLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = ITactDemoConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ITactDemoCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
