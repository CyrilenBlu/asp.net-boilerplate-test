using Abp.AspNetCore.Mvc.Controllers;

namespace blu.MyProject.Web.Controllers
{
    public abstract class MyProjectControllerBase: AbpController
    {
        protected MyProjectControllerBase()
        {
            LocalizationSourceName = MyProjectConsts.LocalizationSourceName;
        }
    }
}