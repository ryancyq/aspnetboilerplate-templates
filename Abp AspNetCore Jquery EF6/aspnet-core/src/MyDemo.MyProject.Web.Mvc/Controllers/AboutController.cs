using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MyDemo.MyProject.Controllers;

namespace MyDemo.MyProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : MyProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
