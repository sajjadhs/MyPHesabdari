using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPHesabdari.Controllers
{
    [Route("[controller]")]
    public class CultureController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult ChangeCulture(string culture, string returnUrl = "")
        {
            this.HttpContext.Response.Cookies.Delete(CookieRequestCultureProvider.DefaultCookieName);
            this.HttpContext.Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
          CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture, culture)),
          new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return LocalRedirect(returnUrl);
        }
    }
}
