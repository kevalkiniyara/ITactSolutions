using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ITactDemo.Configuration;
using Abp.Zero.Configuration;

namespace ITactDemo.Web.Startup
{
    [DependsOn(typeof(ITactDemoWebCoreModule))]
    public class ITactDemoWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ITactDemoWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            //Configuration.MultiTenancy.IsEnabled = true;
            //Configuration.MultiTenancy.TenantIdResolveKey = "Abp-TenantId";
            Configuration.Navigation.Providers.Add<ITactDemoNavigationProvider>();
        }

        public override void Initialize()
        {   
            IocManager.RegisterAssemblyByConvention(typeof(ITactDemoWebMvcModule).GetAssembly());
        }
    }
}
