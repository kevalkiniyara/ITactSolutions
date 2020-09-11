using Microsoft.AspNetCore.Antiforgery;
using ITactDemo.Controllers;

namespace ITactDemo.Web.Host.Controllers
{
    public class AntiForgeryController : ITactDemoControllerBase
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
