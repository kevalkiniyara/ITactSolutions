using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using ITactDemo.Controllers;

namespace ITactDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ITactDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
