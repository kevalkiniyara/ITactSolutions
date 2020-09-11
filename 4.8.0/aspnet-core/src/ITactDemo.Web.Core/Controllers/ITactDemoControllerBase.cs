using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ITactDemo.Controllers
{
    public abstract class ITactDemoControllerBase: AbpController
    {
        protected ITactDemoControllerBase()
        {
            LocalizationSourceName = ITactDemoConsts.LocalizationSourceName;
           
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
