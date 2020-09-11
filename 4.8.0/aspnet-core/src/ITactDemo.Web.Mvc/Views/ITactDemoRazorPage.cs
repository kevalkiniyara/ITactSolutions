using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace ITactDemo.Web.Views
{
    public abstract class ITactDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected ITactDemoRazorPage()
        {
            LocalizationSourceName = ITactDemoConsts.LocalizationSourceName;
        }
    }
}
