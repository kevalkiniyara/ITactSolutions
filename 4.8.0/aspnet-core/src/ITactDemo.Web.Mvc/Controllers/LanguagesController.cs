using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITactDemo.Controllers;
using ITactDemo.Web.Models.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;

namespace ITactDemo.Web.Mvc.Controllers
{
    public class LanguagesController : ITactDemoControllerBase
    {
        private readonly IStringLocalizer<LanguagesController> _stringLocalizer;

        public LanguagesController(IStringLocalizer<LanguagesController> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
        public IActionResult Index()
        {  
            ViewData["Message"] = _stringLocalizer["Order"];
            return View();
        }
        
        [HttpPost]
        public IActionResult SetLanguage(string culture,string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) }
                );
            return LocalRedirect(returnUrl);
        }

        public IActionResult Contact()
        {  
            return View();
        }

        [HttpPost]
        public IActionResult Contact(CreateOrUpdateOrderViewModel input)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            ViewData["Result"] = _stringLocalizer["Success"];
            return View(input);
        }


    }
}