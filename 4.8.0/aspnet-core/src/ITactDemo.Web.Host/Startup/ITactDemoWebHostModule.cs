using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ITactDemo.Configuration;

namespace ITactDemo.Web.Host.Startup
{
    [DependsOn(
       typeof(ITactDemoWebCoreModule))]
    public class ITactDemoWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ITactDemoWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ITactDemoWebHostModule).GetAssembly());
        }
    }
}
