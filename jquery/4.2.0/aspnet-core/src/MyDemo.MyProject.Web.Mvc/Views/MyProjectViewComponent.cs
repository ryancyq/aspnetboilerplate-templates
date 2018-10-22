using Abp.AspNetCore.Mvc.ViewComponents;

namespace MyDemo.MyProject.Web.Views
{
    public abstract class MyProjectViewComponent : AbpViewComponent
    {
        protected MyProjectViewComponent()
        {
            LocalizationSourceName = MyProjectConsts.LocalizationSourceName;
        }
    }
}
