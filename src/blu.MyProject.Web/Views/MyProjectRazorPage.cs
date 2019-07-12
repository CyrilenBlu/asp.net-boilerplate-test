using Abp.AspNetCore.Mvc.Views;

namespace blu.MyProject.Web.Views
{
    public abstract class MyProjectRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected MyProjectRazorPage()
        {
            LocalizationSourceName = MyProjectConsts.LocalizationSourceName;
        }
    }
}
