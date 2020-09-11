using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ITactDemo.Authorization
{
    public class ITactDemoAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Students, L("Student"));
        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ITactDemoConsts.LocalizationSourceName);
        }
    }
}
