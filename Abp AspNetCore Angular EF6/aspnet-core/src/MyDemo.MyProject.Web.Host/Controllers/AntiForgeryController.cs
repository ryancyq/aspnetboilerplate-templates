using Microsoft.AspNetCore.Antiforgery;
using MyDemo.MyProject.Controllers;

namespace MyDemo.MyProject.Web.Host.Controllers
{
    public class AntiForgeryController : MyProjectControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
