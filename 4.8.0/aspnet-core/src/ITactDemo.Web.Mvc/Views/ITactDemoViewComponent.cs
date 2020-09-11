using Abp.AspNetCore.Mvc.ViewComponents;

namespace ITactDemo.Web.Views
{
    public abstract class ITactDemoViewComponent : AbpViewComponent
    {
        protected ITactDemoViewComponent()
        {
            LocalizationSourceName = ITactDemoConsts.LocalizationSourceName;
           // ResourceSourceName = ITactDemoConsts.LocalizationResourceName;
        }
    }
}
