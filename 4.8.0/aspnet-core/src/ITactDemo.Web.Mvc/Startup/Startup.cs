using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Castle.Facilities.Logging;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using ITactDemo.Authentication.JwtBearer;
using ITactDemo.Configuration;
using ITactDemo.Identity;
using ITactDemo.Web.Resources;
using Abp.AspNetCore.SignalR.Hubs;
using ITactDemo.Model.Grid;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;

namespace ITactDemo.Web.Startup
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(option =>
            {
                option.ResourcesPath = "ITactDemo/Localization/ResourceFiles";
            });
            services.Configure<RequestLocalizationOptions>(option =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en"),
                    new CultureInfo("hi")
                };
                option.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
                option.SupportedCultures = supportedCultures;
                option.SupportedUICultures = supportedCultures;
            });

            // MVC
            //services.AddMvc(
            //    options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
            //);

            services.AddMvc(
                options =>
                {
                    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    options.ModelBinderProviders.Insert(0, new GridModelBinderProvider());
                })
                .AddViewLocalization(option =>
                {
                    option.ResourcesPath = "ITactDemo/Localization/ResourceFiles";
                })
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();


            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);

            services.AddScoped<IWebResourceManager, WebResourceManager>();

            services.AddSignalR();

            // Configure Abp and Dependency Injection
            return services.AddAbp<ITactDemoWebMvcModule>(
                // Configure Log4Net logging
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                )
            );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(); // Initializes ABP framework.

            var localizationOption = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();

            app.UseRequestLocalization(localizationOption.Value);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseJwtTokenMiddleware();

            app.UseSignalR(routes =>
            {
                routes.MapHub<AbpCommonHub>("/signalr");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
