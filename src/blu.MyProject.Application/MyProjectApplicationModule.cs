using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace blu.MyProject
{
    [DependsOn(
        typeof(MyProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyProjectApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyProjectApplicationModule).GetAssembly());
        }
    }
}