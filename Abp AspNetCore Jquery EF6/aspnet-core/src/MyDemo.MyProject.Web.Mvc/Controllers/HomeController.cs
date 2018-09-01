using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MyDemo.MyProject.Controllers;

namespace MyDemo.MyProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MyProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
