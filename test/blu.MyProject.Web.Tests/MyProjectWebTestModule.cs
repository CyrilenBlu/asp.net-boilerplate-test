using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using blu.MyProject.Web.Startup;
namespace blu.MyProject.Web.Tests
{
    [DependsOn(
        typeof(MyProjectWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class MyProjectWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyProjectWebTestModule).GetAssembly());
        }
    }
}