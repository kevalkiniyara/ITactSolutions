using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ITactDemo.Authorization;

namespace ITactDemo
{
    [DependsOn(
        typeof(ITactDemoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ITactDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ITactDemoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ITactDemoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
