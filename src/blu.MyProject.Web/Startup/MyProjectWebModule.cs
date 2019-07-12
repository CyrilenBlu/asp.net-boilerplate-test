using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using blu.MyProject.Configuration;
using blu.MyProject.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace blu.MyProject.Web.Startup
{
    [DependsOn(
        typeof(MyProjectApplicationModule), 
        typeof(MyProjectEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class MyProjectWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MyProjectWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(MyProjectConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<MyProjectNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(MyProjectApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyProjectWebModule).GetAssembly());
        }
    }
}